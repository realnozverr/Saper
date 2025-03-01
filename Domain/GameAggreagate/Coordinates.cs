﻿using CSharpFunctionalExtensions;

namespace Domain.GameAggreagate
{
    /// <summary>
    /// Класс с полями являющийся valueobject, так как сравниваем по значению координат.
    /// </summary>
    public class Coordinates : ValueObject<Coordinates>
    {
        private Coordinates(){}
        private Coordinates(int row, int col) : this()
        {
            Row = row;
            Col = col;
        }

        public int Row { get; private set; }
        public int Col { get; private set; }

        public static Coordinates Create(int row, int col)
        {


            return new Coordinates(row, col);
        }

  
        private static bool ValidateCoordinate(int value)
        {
            return value > 0;
        }


        /// <summary>
        /// переопределяем сравнение по значению
        /// </summary>
        /// <param name="other">Координата с который сравниваем</param>
        /// <returns>Возвращем итог сравения</returns>
        protected override bool EqualsCore(Coordinates other)
        {
            if (other == null)
                return false;

            return Row == other.Row && Col == other.Col;
        }

        /// <summary>
        /// переопределяем hashcode
        /// </summary>
        /// <returns>Возвращем объединенный хэшкод</returns>
        protected override int GetHashCodeCore()
        {
            return Row.GetHashCode() ^ Col.GetHashCode();
        }
    }
}
