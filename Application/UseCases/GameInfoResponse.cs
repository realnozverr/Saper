using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public record GameInfoResponse
    {
        private GameInfoResponse(){}
        public GameInfoResponse(Guid gameId, int width, int height, bool completed, string[,] field) :this()
        {
            GameId = gameId;
            Width = width;
            Height = height;
            Completed = completed;
            Field = field;
        }
        public Guid GameId  { get; init; }
        public int Width { get; init; }
        public int Height { get; init; }
        public bool Completed { get; init; }
        public string[,] Field { get; init; }
    }
}
