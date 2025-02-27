using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Ports.GameCache;
using Domain.GameAggreagate;
using MediatR;

namespace Application.UseCases.Commands.AddGame
{
    public class AddGameHandler : IRequestHandler<AddGameCommand, GameInfoResponse>
    {
        private readonly IGameCache _gameCache;
        public AddGameHandler(IGameCache gameCache)
        {
            _gameCache = gameCache;
        }

        public async Task<GameInfoResponse> Handle(AddGameCommand message, CancellationToken cancellationToken)
        {
            var newGame = Game.Create(message.Width, message.Height, message.MinesCount);
            await _gameCache.AddGame(newGame);
            return new GameInfoResponse(
                newGame.Id,
                message.Width,
                message.Height,
                newGame.Status == Status.Completed,
                GameInfoResponse.ConvertFieldToString(newGame.Field)
                );
        }
    }
}
