using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Domain.SharedKernel;

namespace Domain.GameAggreagate
{
    public class Game : Aggregate
    {
        private Game(){}

        private Game(int row, int col, int minesCount) : this()
        {
            Field = new Cell[row, col];
            Status = Status.Incomplete;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Field[i, j] = Cell.Create(row, col);
                }
            }
        }

        public Cell[,] Field { get; private set; } = null!;
        public Status Status { get; private set; } = null!;

        public static Game Create()
        {

        }

        private static bool ValidateGame(int row, int col, int minesCount)
        {
            return row >= 2 && row <= 30 &&
                   col >= 2 && col <= 30 &&
                   minesCount > 0 && minesCount < (row * col);
        }
    }
}
