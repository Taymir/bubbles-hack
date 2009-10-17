using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BubblesHack.Solvers
{
    abstract class Solver
    {
        protected BubbleGrid grid;

        public Solver(BubbleGrid grid)
        {
            this.grid = grid;
        }

        abstract public int solve();
    }
}
