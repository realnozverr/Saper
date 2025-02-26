using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.GameAggreagate;

namespace Domain.Services
{
    public interface ITurnCellService
    {
        Task<Game> TurnCell(Guid gameId, int row, int col);
    }
}
