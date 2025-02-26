using Domain.GameAggreagate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports.GameCache
{
    public interface IGameCache
    {
        Task<Game> GetGame(Guid gameId);
        Task AddGame(Game game);
        Task UpdateGame(Game game);
    }
}
