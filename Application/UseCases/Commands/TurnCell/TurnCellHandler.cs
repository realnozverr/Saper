using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Ports.GameCache;
using Domain.GameAggreagate;
using MediatR;

namespace Application.UseCases.Commands.TurnCell
{
    public class TurnCellHandler : IRequestHandler<TurnCellCommand, GameInfoResponse>
    {
        private readonly IGameCache _gameCache;
        public TurnCellHandler(IGameCache gameCache)
        {
            _gameCache = gameCache;
        }
        public async Task<GameInfoResponse> Handle(TurnCellCommand command, CancellationToken cancellationToken)
        {
            var game = await _gameCache.GetGame(command.GameId);
            game.TurnCell(command.Row, command.Row);
            return new GameInfoResponse(
                game.Id,
                game.Field.GetLength(0),
                game.Field.GetLength(1),
                game.MinesCount,
                game.Status == Status.Completed,
                GameInfoResponse.ConvertFieldToString(game.Field)
                );
        }
    }
}
