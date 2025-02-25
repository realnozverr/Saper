using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.UseCases.Commands.AddGame
{
    public class AddGameHandler : IRequestHandler<AddGameCommand, GameInfoResponse>
    {
        public AddGameHandler()
        {
               
        }

        public async Task<GameInfoResponse> Handle(AddGameCommand message, CancellationToken cancellationToken)
        {

        }
    }
}
