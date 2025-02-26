using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.GameAggreagate;

namespace Domain.Services
{
    public interface IGameCreateService
    {
        Task<Game> CreateGame(int row, int col, int minesCount);
    }
}
