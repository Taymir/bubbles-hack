using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BubblesHack.Solvers
{
    class SortColourRandomSolver : PersistantSolver
    {
        private static Dictionary<BubbleColor, int> colorsPersistant;
        private Dictionary<BubbleColor, int> colors;
        private Random rnd;
         
        public SortColourRandomSolver(BubbleGrid grid)
            : this(grid, false) { }

        public SortColourRandomSolver(BubbleGrid grid, bool persist)
            : base(grid)
        {
            rnd = new Random();

            if (persist)
            {
                if (colorsPersistant == null)
                    startPersistance(grid);

                colors = colorsPersistant;
            }
            else
            {
                colors = sortColors(grid);
            }
        }

        public new static void startPersistance(BubbleGrid grid)
        {
            colorsPersistant = sortColors(grid);
        }

        public new static void stopPersistance()
        {
            colorsPersistant = null;
        }

        override public Move? oneStep()
        {
            if (grid.findAllMoves() > 0)
            {
                shellSort(grid.availableMoves, 0, grid.availableMovesCount - 1);
                int n = lastEqualMove(grid.availableMoves, 0, grid.availableMovesCount - 1);

                Move randomMove = grid.availableMoves[rnd.Next(n)];

                grid.clickAt(randomMove);

                return randomMove;
            }

            return null;
        }

        private void shellSort(Move[] a, int l, int r)
        { 
            int h; 
            for (h = 1; h <= (r - l) / 9; h = 3 * h + 1) ;
            for ( ; h > 0; h /= 3)
              for (int i = l + h; i <= r; i++)
                {
                    int j = i;
                    Move v = a[i]; 
                    while (
                        j >= l + h &&
                        colors[v.bubbleColor] < colors[a[j - h].bubbleColor]
                        )
                    {
                        a[j] = a[j - h];
                        j -= h;
                    }
                    a[j] = v; 
                }
        }

        private int lastEqualMove(Move[] a, int l, int r)
        {
            int i = l + 1;
            while (
                i <= r &&
                Math.Abs(colors[a[0].bubbleColor] - colors[a[i].bubbleColor]) < 10
                )
                i++;

            return i;
        }

        public static Dictionary<BubbleColor, int> sortColors(BubbleGrid grid)
        {
            return grid.counter;
        }
    }
}
