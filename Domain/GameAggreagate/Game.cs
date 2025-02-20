using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Domain.GameAggreagate
{
    public class Game : Entity<Guid> ///решил что будет агрегатом а не ентити
    {
        private Game(){}

        private Game(string width, string weight, int minesCount) : this()
        {
            
        }
    }
}
