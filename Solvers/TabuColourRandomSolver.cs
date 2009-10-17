using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BubblesHack.Solvers
{
    class TabuColourRandomSolver : PersistantSolver
    {
        private static BubbleColor? tabuPersistant;
        private BubbleColor tabu;
        private Random rnd;

        public TabuColourRandomSolver(BubbleGrid grid)
            : this(grid, false) { }

        public TabuColourRandomSolver(BubbleGrid grid, bool persist)
            : base(grid)
        {
            rnd = new Random();

            if (persist)
            {
                if (!tabuPersistant.HasValue)
                    startPersistance(grid);

                tabu = tabuPersistant.Value;
            }
            else
            {
                tabu = pickMostFreqColor(grid);
            }
        }

        public new static void startPersistance(BubbleGrid grid)
        {
            tabuPersistant = pickMostFreqColor(grid);
        }

        public new static void stopPersistance()
        {
            tabuPersistant = null;
        }

        override public Move? oneStep()
        {
            if (grid.findAllMoves() > 0)
            {
                //@OPTIMIZE
                bool[] taboos = new bool[grid.availableMovesCount];
                int taboosNum = 0;

                for (int i = 0; i < grid.availableMovesCount; i++)
                {
                    if (grid.availableMoves[i].bubbleColor == tabu)
                    {
                        taboos[i] = true;
                        taboosNum++;
                    }
                }

                int moveNum = 0;

                if (taboosNum == grid.availableMovesCount)
                {
                    moveNum = rnd.Next(grid.availableMovesCount);
                }
                else
                {
                    do
                    {
                        moveNum = rnd.Next(grid.availableMovesCount);
                    } while (grid.availableMoves[moveNum].bubbleColor == tabu);
                }

                Move randomMove = grid.availableMoves[moveNum];

                grid.clickAt(randomMove);

                return randomMove;
            }

            return null;
        }

        public static BubbleColor pickMostFreqColor(BubbleGrid grid)
        {
            BubbleColor bestCol = BubbleColor.Blue;
            int bestAmount = 0;

            for (int i = 0; i < 5; i++)
            {
                BubbleColor curCol = (BubbleColor)i;
                if (grid.counter[curCol] > bestAmount)
                {
                    bestCol = curCol;
                    bestAmount = grid.counter[curCol];
                }
            }

            return bestCol;
        }
    }
}
