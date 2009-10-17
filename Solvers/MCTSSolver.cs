using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BubblesHack.Solvers
{
    delegate void ProgressEventHandler(int progress, int score, int seconds, int nods, double avgScore);

    class MCTSSolver : Solver
    {
        public double C = 0.1;                // Exploitation
        public double D = 320.0;         // Exploration
        public int minThreshold = 10;       // Min simulations per node
        public int maxNodes = 1000;          // Max nodes amount

        public event ProgressEventHandler onProgress;

        public string solverType = "BubblesHack.Solvers.TabuColourRandomSolver";

        public int bestScore;
        public List<Move> bestHistory;

        private int sum = 0;        //@TMP

        private int nodesCount;
        private Node root;
        private double avgScore
        {
            get
            {
                //return root.avgScore + root.score / nodesCount;
                return sum / nodesCount;
            }
        }

        public MCTSSolver(BubbleGrid grid)
            : base(grid)
        {
            bestScore = 0;
            nodesCount = 0;
        }

        public override int solve()
        {
            root = new Node();
            root.bubbles = this.grid;

            long start = DateTime.Now.Ticks;
            long end;

            // Если solver типа persistantSolver (т.е. вычисляет какие-то предварительные значения) - вызывать solver.startPersistance (чтобы сохранить предв. значения)
            Type solver = Type.GetType(this.solverType, true, true);
            if (solver.IsSubclassOf(Type.GetType("BubblesHack.Solvers.PersistantSolver")))
                solver.GetMethod("startPersistance").Invoke(null, new object[] { grid });

            while (nodesCount < maxNodes)
            {
                Node N = select(root);
                simulate(N);

                end = (DateTime.Now.Ticks - start ) / 10000000;
                this.onProgress(nodesCount * 100 / maxNodes, bestScore, (int)end, nodesCount, avgScore);
            }

            // Если solver типа persistantSolver (т.е. вычисляет какие-то предварительные значения) - вызывать solver.stopPersistance (чтобы сбросить предв. значения)
            if (solver.IsSubclassOf(Type.GetType("BubblesHack.Solvers.PersistantSolver")))
                solver.GetMethod("stopPersistance").Invoke(null, null);

            return bestScore;
        }

        public void solveQuietly()
        {
            this.solve();
        }

        private Node select(Node N)
        {
            double bestValue = 0;
            Node bestNode = N;

            if (bestNode.visited > minThreshold)
            {

                foreach (Node child in N.children)
                {
                    //@BUGGGGGGGGGYYYYY!!!!!!!!!!!!!!!!!!!!
                    double UCT =
                        //avgScore +
                        C * (Math.Log(N.visited) / child.visited) ;//+
                        //((child.sumSqrScores - child.visited * avgScore * avgScore + D) / child.visited);

                    //double UCT =
                    //    avgScore + C *
                    //    Math.Sqrt(Math.Log(N.visited) / child.visited) +
                    //    Math.Sqrt((child.sumSqrScores - child.visited * avgScore * avgScore + D) / child.visited);


                    if (UCT > bestValue)
                    {
                        bestValue = UCT;
                        bestNode = child;
                    }

                    //if (double.IsNaN(UCT))//@DEBUG
                    //    System.Windows.Forms.MessageBox.Show("WOW! UCT=" + UCT.ToString());
                }

                if (N != bestNode && bestNode.visited > minThreshold)
                {
                    select(bestNode);
                }
            }
            bestNode.visited++;

            return bestNode;
        }

        private void simulate(Node N)
        {
            BubbleGrid bubbles = N.bubbles;
            // Создаем объект по названию, данному в this.solverType
            SimpleSolver solver = (SimpleSolver)Activator.CreateInstance(Type.GetType(this.solverType, true, true), new object[] { bubbles });

            Move? step;
            Node childNode;

            do
            {
                // Делаем шаг
                step = solver.oneStep();

                // Если шаг сделан, то
                if (step.HasValue)
                {
                    // Ищем существующюю ноду с таким же шагом
                    childNode = N.findChild(step.Value);
                    
                    //@TMP
                    if (childNode != null)
                    {
                        childNode.visited++;
                        N = childNode;//@BUG around here somewhere
                    }
                }
                else
                {
                    // Нода находится в самом конце дерева решений
                    // отсюда симуляция невозможна, выходим
                    return; 
                }
            } while (childNode != null); // Повторять если найдена существующая нода

            // Наконец, N - нода-лист, экспэндим её (добавляем к ней дочернюю ноду с нашим последним шагом)
            N = expand(N, bubbles.Clone(), step.Value);

            // Симулируем игру до конца
            int score = solver.solve();

            // И сохраняем все результаты
            backPropagate(N, score, bubbles);
        }

        private Node expand(Node parent, BubbleGrid bubbles, Move step)
        {
            Node child = new Node();
            child.bubbles = bubbles;
            child.step = step;
            child.visited = 1;
            parent.addChild(child);
            this.nodesCount++;

            return child;
        }

        private void backPropagate(Node N, int newScore, BubbleGrid simulatedGrid)
        {
            N.score = newScore;
            this.sum += newScore;

            if (N.score > bestScore)
            {
                bestScore = N.score;
                bestHistory = simulatedGrid.movesHistory;
            }

            while (N.parent != null)
            {
                N = N.parent;
                double avgScore = 0.0;
                double sumSqrScores = 0.0;
                foreach (Node child in N.children)
                {
                    avgScore += child.score;// doesn't work
                    sumSqrScores += child.score * child.score;// doesn't work
                }
                avgScore /= N.children.Count;

                N.avgScore = avgScore;
                N.sumSqrScores = sumSqrScores;
            }
        }

        public void dumpToFile(string filename)
        {
            System.IO.StreamWriter stream = new System.IO.StreamWriter(filename);

            dumpNode(this.root, stream, 0);

            stream.Flush();
            stream.Close();
        }

        private void dumpNode(Node N, System.IO.StreamWriter stream, int offset)
        {
            for (int i = 0; i < offset; i++)
                stream.Write(" ");

            stream.WriteLine("N{s: "+N.score.ToString()+" ;v: "+N.visited.ToString()+" ;}");

            foreach (Node child in N.children)
                dumpNode(child, stream, offset + 1);
        }
    }

    class Node
    {
        public int visited;
        public double avgScore;
        public double sumSqrScores;
        public int score;

        public Node parent;
        public List<Node> children;
        public Move step;

        public BubbleGrid bubbles
        {
            get
            {
                return this.grid.Clone();
            }
            set
            {
                this.grid = value;
            }
        }

        public Node()
        {
            this.visited = 0;
            this.avgScore = 0;
            this.sumSqrScores = 0;
            this.parent = null;
            this.children = new List<Node>();
        }

        private BubbleGrid grid;

        public void addChild(Node child)
        {
            child.parent = this;
            this.children.Add(child);
        }

        public Node findChild(Move move)
        {
            foreach (Node child in children)
                if (child.step.row == move.row &&
                   child.step.col == move.col &&
                   child.step.bubbleColor == move.bubbleColor &&
                   child.step.bubbleCount == move.bubbleCount)
                    return child;

            return null;

        }

    }
}
