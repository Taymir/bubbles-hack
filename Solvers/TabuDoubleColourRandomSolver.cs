using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BubblesHack.Solvers
{
    class TabuDoubleColourRandomSolver : PersistantSolver
    {
        private static BubbleColor? tabu1Persistant;
        private static BubbleColor? tabu2Persistant;

        private BubbleColor tabu1;
        private BubbleColor tabu2;

        private Random rnd;

        public TabuDoubleColourRandomSolver(BubbleGrid grid)
            : this(grid, false){ }

        public TabuDoubleColourRandomSolver(BubbleGrid grid, bool persist)
            : base(grid)
        {
            rnd = new Random();

            if (persist)
            {
                if (!tabu1Persistant.HasValue)
                    startPersistance(grid);

                tabu1 = tabu1Persistant.Value;
                tabu2 = tabu2Persistant.Value;
            }
            else
            {
                tabu1 = pickMostFreqColor(grid);
                tabu2 = pickMostFreqColor(grid, tabu1);
            }
        }

        public new static void startPersistance(BubbleGrid grid)
        {
            tabu1Persistant = pickMostFreqColor(grid);
            tabu2Persistant = pickMostFreqColor(grid, tabu1Persistant.Value);
        }

        public new static void stopPersistance()
        {
            tabu1Persistant = null;
            tabu1Persistant = null;
        }

        override public Move? oneStep()
        {
            if (grid.findAllMoves() > 0)
            {
                //@OPTIMIZE
                //bool[] taboos = new bool[grid.availableMovesCount];
                int taboosNum1 = 0;
                int taboosNum2 = 0;

                for (int i = 0; i < grid.availableMovesCount; i++)
                {
                    if (grid.availableMoves[i].bubbleColor == tabu1)
                    {
                        taboosNum1++;
                    }
                    else if (grid.availableMoves[i].bubbleColor == tabu2)
                    {
                        taboosNum2++;
                    }
                }

                int moveNum = 0;

                if (taboosNum1 + taboosNum2 == grid.availableMovesCount)
                {
                    if (taboosNum2 != 0)
                    {
                        do
                        {
                            moveNum = rnd.Next(grid.availableMovesCount);
                        } while (grid.availableMoves[moveNum].bubbleColor == tabu1);

                    }
                    else
                    {
                        moveNum = rnd.Next(grid.availableMovesCount);
                    }
                }
                else
                {
                    do
                    {
                        moveNum = rnd.Next(grid.availableMovesCount);
                    } while (grid.availableMoves[moveNum].bubbleColor == tabu1 || grid.availableMoves[moveNum].bubbleColor == tabu2);
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

        public static BubbleColor pickMostFreqColor(BubbleGrid grid, BubbleColor tabu)
        {
            BubbleColor bestCol = BubbleColor.Blue;

            int bestAmount = 0;

            for (int i = 0; i < 5; i++)
            {
                BubbleColor curCol = (BubbleColor)i;
                if (curCol == tabu) continue;
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
