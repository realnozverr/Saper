using MediatR;

namespace Application.UseCases.Commands.AddGame
{
    public class AddGameCommand : IRequest<bool>
    {
        public AddGameCommand()
        {
            
        }
    }
}
