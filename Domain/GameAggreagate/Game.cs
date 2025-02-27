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
            Id = Guid.NewGuid();
            MinesCount = minesCount;
            Field = new Cell[row, col];
            Status = Status.Incomplete;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Field[i, j] = Cell.Create(i, j);
                }
            }

            PlaceMines(row, col, minesCount);
        }

        public Guid Id { get; private set; }
        public int MinesCount { get; private set; } 
        public Cell[,] Field { get; private set; } = null!;
        public Status Status { get; private set; } = null!;
        private static readonly Random Rand = new Random();

        public static Game Create(int row, int col, int minesCount)
        {
            if (row < 2 || row > 30)
                throw new ArgumentException($"{nameof(row)} must be between 2 and 30.");
            if (col < 2 || col > 30)
                throw new ArgumentException($"{nameof(col)} must be between 2 and 30.");
            if (minesCount <= 0)
                throw new ArgumentException($"{nameof(minesCount)} must be greater than 0.");
            if (minesCount >= (row * col))
                throw new ArgumentException($"{nameof(minesCount)} must be less than the total number of cells ({row * col}).");
            return new Game(row, col, minesCount);
        }

        private void PlaceMines(int row, int col, int minesCount)
        {
            int plantedMines = 0;

            while (plantedMines < minesCount)
            {
                int randomRow = Rand.Next(row);
                int randomCol = Rand.Next(col);

                if (!Field[randomRow, randomCol].IsMined)
                {
                    Field[randomRow, randomCol].PlaceMine();
                    plantedMines++;
                }
            }
        }

        public Cell[,] All(Status status)
        {
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    if (Field[i, j].IsMined)
                    {
                        Field[i, j].SetValue(status == Status.Lose ? "X" : "M");
                    }
                    else
                    {
                        Field[i, j].SetValue(CountMinesAround(i, j).ToString());
                    }
                }
            }
            return Field;
        }

        public Cell[,] TurnCell(int row, int col)
        {
            if (Field[row, col] == null)
            {
                throw new ArgumentException($"Cell at ({row}, {col}) is not initialized.");
            }

            if (Field[row, col].IsMined)
            {
                All(Status.Lose);
                return Field; 
            }

            
            OpenCell(row, col);
            MinesCount--;

            if (MinesCount == 0)
            {
                All(Status.Completed);
            }

            return Field;
        }

        private void OpenCell(int row, int col)
        {
           
            if (row < 0 || row >= Field.GetLength(0) || col < 0 || col >= Field.GetLength(1))
            {
                return;
            }

            Cell cell = Field[row, col];

            if (cell.IsOpened || cell.IsMined)
            {
                return; 
            }

            cell.Open(); 

            
            int mineCount = CountMinesAround(row, col);
            cell.SetValue(mineCount.ToString());

            
            if (mineCount == 0)
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i == 0 && j == 0) continue; 
                        OpenCell(row + i, col + j); 
                    }
                }
            }
        }

        private int CountMinesAround(int row, int col)
        {
            int mineCount = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int neighborRow = row + i;
                    int neighborCol = col + j;

                    if (neighborRow >= 0 && neighborRow < Field.GetLength(0) &&
                        neighborCol >= 0 && neighborCol < Field.GetLength(1))
                    {
                        if (Field[neighborRow, neighborCol].IsMined)
                        {
                            mineCount++;
                        }
                    }
                }
            }

            return mineCount;
        }
    }
}
