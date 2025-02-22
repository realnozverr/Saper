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

        private Game(string width, string weight, int minesCount) : this()
        {
            
        }

        public Cell[,] Field {  get; private set; }
    }
}
