using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BubblesHack.Solvers
{
    class HundredTimesSolver : Solver
    {
        public HundredTimesSolver(BubbleGrid grid) : base(grid) { }

        public override int solve()
        {
            int bestScore = 0;

            for (int i = 0; i < 100; i++)
            {
                BubbleGrid currentGrid = grid.Clone();
                Solver solver = new TabuColourRandomSolver(currentGrid);
                int currentScore = solver.solve();
                if (currentScore > bestScore)
                    bestScore = currentScore;
            }

            return bestScore;
        }
    }
}
