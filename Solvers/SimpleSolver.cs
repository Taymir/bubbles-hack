using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BubblesHack.Solvers
{
    abstract class SimpleSolver : Solver
    {
        public SimpleSolver(BubbleGrid grid) : base(grid) { }

        override public int solve()
        {
            Move? randomMove = null;
            do
            {
                randomMove = oneStep();
            } while (randomMove != null);

            return grid.getScore();
        }

        abstract public Move? oneStep();
    }
}
