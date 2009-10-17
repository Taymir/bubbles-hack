using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BubblesHack.Solvers
{
    class RandomSolver : SimpleSolver
    {
        protected Random rnd;

        public RandomSolver(BubbleGrid grid)
            : base(grid)
        {
            rnd = new Random();
        }

        override public Move? oneStep()
        {
            if (grid.findAllMoves() > 0)
            {
                Move randomMove = grid.availableMoves[rnd.Next(grid.availableMovesCount)];
                grid.clickAt(randomMove.row, randomMove.col);

                return randomMove;
            }

            return null;
        }
    }
}
