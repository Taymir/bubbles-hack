using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BubblesHack.Solvers
{
    abstract class PersistantSolver : SimpleSolver
    {
        public PersistantSolver(BubbleGrid grid) : base(grid) { }

        public static void startPersistance(BubbleGrid grid)
        {
        }
        public static void stopPersistance()
        {
        }
    }
}
