using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Domain.GameAggreagate
{
    public class Cell : Entity<int>
    {
        private Cell() { }

        private Cell(int row, int col) : this()
        {
            Coordinates = Coordinates.Create(row, col); 
        }

        public int IsMineCount { get; private set; }
        public string Value { get; private set; } = " ";
        public bool IsMined { get; private set; } = false;
        public Coordinates Coordinates { get; private set; } = null!;

        public static Cell Create(int row, int col)
        {
            return new Cell(row, col);
        }

        public static Cell FindCell(Cell[,] field, int row, int col)
        {
            return field[row, col];
        }

        public static bool operator ==(Cell? a, Cell? b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Coordinates.Col == b.Coordinates.Col && a.Coordinates.Row == b.Coordinates.Row;
        }

        public static bool operator !=(Cell? a, Cell? b) => !(a == b);
    }
}
