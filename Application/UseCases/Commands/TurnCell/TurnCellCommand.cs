using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MediatR;

namespace Application.UseCases.Commands.TurnCell
{
    public class TurnCellCommand : IRequest<GameInfoResponse>
    {
        [JsonPropertyName("game_id")]
        public Guid GameId { get; }

        [JsonPropertyName("col")]
        public int Col {  get; }

        [JsonPropertyName("row")]
        public int Row { get; }

        public TurnCellCommand(Guid game_id, int col, int row)
        {
            GameId = game_id;
            Col = col;
            Row = row;
        }
    }
}
