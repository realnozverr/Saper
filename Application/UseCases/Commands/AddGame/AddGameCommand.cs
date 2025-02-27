using MediatR;
using Domain.GameAggreagate;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text.Json.Serialization;

namespace Application.UseCases.Commands.AddGame
{
    public class AddGameCommand : IRequest<GameInfoResponse>
    {
        
        [JsonPropertyName("width")]
        public int Width { get; }
        [JsonPropertyName("height")]
        public int Height { get; }
        [JsonPropertyName("mines_count")]
        public int MinesCount { get; }

        public AddGameCommand(int mines_count, int width, int height)
        {
            Width = width;
            Height = height;
            MinesCount = mines_count;
        }
    }
}
