using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BubblesHack
{
    public enum BubbleColor
    {
        Blue,
        Red,
        Green,
        Orange,
        Pink,
        Unknown,
        None
    }

    public struct Move
    {
        public BubbleColor bubbleColor;
        public int bubbleCount;
        public int row;
        public int col;

        public int scoreCount
        {
            get
            {
                return BubbleGrid.bubbles2score(bubbleCount);
            }
        }
    }

    public class BubbleGrid
    {
        public const int totalCols = 19;
        public const int totalRows = 11;

        public Move[] availableMoves;
        public byte availableMovesCount;

        public List<Move> movesHistory;

        public bool endGame;

        public Dictionary<BubbleColor, int> counter;

        private BubbleColor[,] grid;
        private static byte[,] cacheGrid = new byte[totalRows, totalCols]; // this makes BubbleGrid class multithread-unsafe!!

        private int score;

        private const byte EMPTY = 0xFF;

        public BubbleGrid()
        {
            grid = new BubbleColor[totalRows, totalCols];
            counter = new Dictionary<BubbleColor, int>(5);

            counter.Add(BubbleColor.Blue, 0);
            counter.Add(BubbleColor.Red, 0);
            counter.Add(BubbleColor.Green, 0);
            counter.Add(BubbleColor.Orange, 0);
            counter.Add(BubbleColor.Pink, 0);

            clearBubbles();

            //cacheGrid = new byte[totalRows, totalCols];
            availableMoves = new Move[totalRows * totalCols / 2];
        }

        public BubbleGrid Clone()
        {
            BubbleGrid clone = new BubbleGrid();

            for (int row = 0; row < totalRows; ++row)
            {
                for (int col = 0; col < totalCols; ++col)
                {
                    clone.setBubble(row, col, this.grid[row, col]);
                }
            }

            clone.movesHistory.AddRange(this.movesHistory);
            clone.score = this.score;
            
            clone.endGame = this.endGame;
            return clone;
        }

        public void clearBubbles()
        {
            for (int row = 0; row < totalRows; ++row)
            {
                for (int col = 0; col < totalCols; ++col)
                {
                    grid[row, col] = BubbleColor.None;
                }
            }
            this.endGame = false;
            score = 0;

            movesHistory = new List<Move>();
        }

        public void setBubble(int row, int col, BubbleColor bubble)
        {
            grid[row, col] = bubble;
            if(counter.ContainsKey(bubble))
                counter[bubble]++;
        }

        public BubbleColor getBubble(int row, int col)
        {
            return grid[row, col];
        }

        public int getScore()
        {
            return this.score;
        }

        static public int bubbles2score(int bubblesNum)
        {
            return (int)(Math.Pow(bubblesNum, 2) * 5 - bubblesNum * 5);
        }

        public int clickAt(int row, int col)
        {
            BubbleColor bubble = grid[row, col];
            if (bubble != BubbleColor.None && hasNeighbours(row, col))
            {
                int bubblesKilled = recoursiveBubblesKill(row, col);
                counter[bubble] -= bubblesKilled;
                score += bubbles2score(bubblesKilled);
                collapseBubbles();

                Move move = new Move();
                move.bubbleColor = bubble;
                move.bubbleCount = bubblesKilled;
                move.col = col;
                move.row = row;
                this.movesHistory.Add(move);

                return bubblesKilled;
            }

            return 0;
        }

        // Функция полагается на корректность move.
        public int clickAt(Move move)
        {
            int bubblesKilled = recoursiveBubblesKill(move.row, move.col);

            if (bubblesKilled != move.bubbleCount)
                //throw new Exception("The move is incorrect");//@TMP
                System.Windows.Forms.MessageBox.Show("Error: loaded move is incorrect");

            counter[move.bubbleColor] -= bubblesKilled;
            score += bubbles2score(bubblesKilled);
            collapseBubbles();
            this.movesHistory.Add(move);

            return bubblesKilled;
        }

        private void collapseBubbles()
        {
            // Сдвиг вниз
            int to = -1;
            for (int col = 0; col < totalCols; col++)
            {
                to = -1;
                for (int row = totalRows - 1; row >= 0; row--)
                {
                    if (to == -1 && grid[row, col] == BubbleColor.None) 
                    {
                        to = row;
                    }
                    else if (to != -1 && grid[row, col] != BubbleColor.None)
                    {
                        grid[to, col] = grid[row, col];
                        grid[row, col] = BubbleColor.None;
                        to--;
                    }
                }
            }

            // Сдвиг вправо
            to = -1;
            for (int row = 0; row < totalRows; row++)
            {
                to = -1;
                for (int col = totalCols - 1; col >= 0; col--)
                {
                    if (to == -1 && grid[row, col] == BubbleColor.None)
                    {
                        to = col;
                    }
                    else if (to != -1 && grid[row, col] != BubbleColor.None)
                    {
                        grid[row, to] = grid[row, col];
                        grid[row, col] = BubbleColor.None;
                        to--;
                    }
                }
            }
            
        }

        public int findAllMoves()
        {
            clearCache();

            availableMovesCount = 0;

            
            for (int row = 0; row < totalRows; row++)
            {
                for (int col = 0; col < totalCols; col++)
                {
                    if (grid[row, col] != BubbleColor.None)
                    {
                        int marked = recoursiveBubbleMark(row, col, availableMovesCount);
                        if (marked > 1)
                        {
                            availableMoves[availableMovesCount].bubbleCount = marked;
                            availableMoves[availableMovesCount].bubbleColor = grid[row, col];
                            availableMoves[availableMovesCount].row = row;
                            availableMoves[availableMovesCount].col = col;

                            availableMovesCount++;
                        }
                    }
                }
            }

            if (availableMovesCount == 0)
                this.endGame = true;

            return availableMovesCount;
        }

        public System.Drawing.Point[] findAdjacentBubbles(int row, int col)
        {
            clearCache();

            int marked = this.recoursiveBubbleMark(row, col, 0xAA);
            List<System.Drawing.Point> points = new List<System.Drawing.Point>(marked);

            for (int r = 0; r < totalRows; r++)
                for (int c = 0; c < totalCols; c++)
                    if (cacheGrid[r, c] == 0xAA)
                        points.Add(new System.Drawing.Point(c, r));

            return points.ToArray();
        }

        private static void clearCache()
        {
            for (int row = 0; row < totalRows; row++)
                for (int col = 0; col < totalCols; col++)
                    cacheGrid[row, col] = EMPTY;
        }

        private int recoursiveBubblesKill(int row, int col)
        {
            int kills = 1;
            BubbleColor bubble = grid[row, col];
            grid[row, col] = BubbleColor.None;

            if (row > 0 && bubble == grid[row - 1, col]) kills += recoursiveBubblesKill(row - 1, col);
            if (col > 0 && bubble == grid[row, col - 1]) kills += recoursiveBubblesKill(row, col - 1);
            if (row < totalRows - 1 && bubble == grid[row + 1, col]) kills += recoursiveBubblesKill(row + 1, col);
            if (col < totalCols - 1 && bubble == grid[row, col + 1]) kills += recoursiveBubblesKill(row, col + 1);

            return kills;
        }

        private bool hasNeighbours(int row, int col)
        {
            BubbleColor bubble = grid[row, col];

            if (row > 0 && bubble == grid[row - 1, col]) return true;
            if (col > 0 && bubble == grid[row, col - 1]) return true;
            if (row < totalRows - 1 && bubble == grid[row + 1, col]) return true;
            if (col < totalCols - 1 && bubble == grid[row, col + 1]) return true;

            return false;
        }

        private int recoursiveBubbleMark(int row, int col, byte marker)
        {
            // Если уже проходили по этой точке - выходим.
            if (cacheGrid[row, col] != EMPTY)
                return 0;

            int marks = 1;
            BubbleColor bubble = grid[row, col];

            if (row > 0 && bubble == grid[row - 1, col])
            {
                cacheGrid[row, col] = marker;
                marks += recoursiveBubbleMark(row - 1, col, marker);
            }
            if (col > 0 && bubble == grid[row, col - 1])
            {
                cacheGrid[row, col] = marker;
                marks += recoursiveBubbleMark(row, col - 1, marker);
            }
            if (row < totalRows - 1 && bubble == grid[row + 1, col])
            {
                cacheGrid[row, col] = marker;
                marks += recoursiveBubbleMark(row + 1, col, marker);
            }
            if (col < totalCols - 1 && bubble == grid[row, col + 1])
            {
                cacheGrid[row, col] = marker;
                marks += recoursiveBubbleMark(row, col + 1, marker);
            }


            return marks;
        }

        public static void saveToFile(BubbleGrid grid, System.IO.Stream stream)
        {
            System.IO.StreamWriter text = new System.IO.StreamWriter(stream);

            for (int row = 0; row < totalRows; row++)
            {
                for (int col = 0; col < totalCols; col++)
                {
                    switch (grid.getBubble(row, col))
                    {
                        case BubbleColor.Blue:
                            text.Write("B");
                            break;
                        case BubbleColor.Green:
                            text.Write("G");
                            break;
                        case BubbleColor.Orange:
                            text.Write("O");
                            break;
                        case BubbleColor.Pink:
                            text.Write("P");
                            break;
                        case BubbleColor.Red:
                            text.Write("R");
                            break;
                        default:
                            text.Write(" ");
                            break;
                    }
                }
                text.Write(text.NewLine);
            }
            text.Close();
        }

        public static BubbleGrid loadFromFile(System.IO.Stream stream)
        {
            BubbleGrid grid = new BubbleGrid();
            System.IO.StreamReader text = new System.IO.StreamReader(stream);

            for (int row = 0; row < totalRows; row++)
            {
                string line = text.ReadLine();
                for (int col = 0; col < totalCols; col++)
                {
                    switch (line[col])
                    {
                        case 'B':
                            grid.setBubble(row, col, BubbleColor.Blue);
                            break;
                        case 'G':
                            grid.setBubble(row, col, BubbleColor.Green);
                            break;
                        case 'O':
                            grid.setBubble(row, col, BubbleColor.Orange);
                            break;
                        case 'P':
                            grid.setBubble(row, col, BubbleColor.Pink);
                            break;
                        case 'R':
                            grid.setBubble(row, col, BubbleColor.Red);
                            break;
                        case ' ':
                            grid.setBubble(row, col, BubbleColor.None);
                            break;
                        default:
                            throw new Exception("Unknown file format");
                    }
                }
            }


            return grid;
        }
    }
}
