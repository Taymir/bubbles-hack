using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BubblesHack.Solvers
{
    class FirstChoiceSolver : SimpleSolver
    {

        public FirstChoiceSolver(BubbleGrid grid)
            : base(grid)
        {
        }

        override public Move? oneStep()
        {
            if (grid.findAllMoves() > 0)
            {
                Move randomMove = grid.availableMoves[0];
                grid.clickAt(randomMove.row, randomMove.col);

                return randomMove;
            }

            return null;
        }
    }
}