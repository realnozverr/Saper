using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.UseCases.Commands.TurnCell
{
    public class TurnCellHandler : IRequestHandler<TurnCellCommand, GameInfoResponse>
    {
        public Task<GameInfoResponse> Handle(TurnCellCommand command, CancellationToken cancellationToken)
        {

        }
    }
}
