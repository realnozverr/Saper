using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Domain.GameAggreagate;

namespace Domain.Services
{
    public class GameCreateService : IGameCreateService
    {
        public Task<Game> CreateGame(int row, int col, int minesCount)
        {
           var newGame = Game.Create(row, col, minesCount);
            return Task.FromResult(newGame);
        }
    }
}
