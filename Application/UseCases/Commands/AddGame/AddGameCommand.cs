using MediatR;
using Domain.GameAggreagate;
using System.Diagnostics.Metrics;
using System.IO;

namespace Application.UseCases.Commands.AddGame
{
    public class AddGameCommand : IRequest<GameInfoResponse>
    {
        public int Width { get; }
        public int Height { get; }
        public int MinesCount { get; }

        public AddGameCommand(int mines_count, int width, int height)
        {

            Width = width;
            Height = height;
            MinesCount = mines_count;
        }
    }
}
