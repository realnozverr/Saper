using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.GameAggreagate;

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

        public static string[,] ConvertFieldToString(Cell[,] field)
        {
            string[,] stringField = new string[field.GetLength(0), field.GetLength(1)];

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    stringField[i, j] = field[i, j].Value;
                }
            }
            return stringField;
        }
    }
}
