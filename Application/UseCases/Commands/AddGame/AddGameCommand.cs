using MediatR;
using Domain.GameAggreagate;
using System.Diagnostics.Metrics;
using System.IO;

namespace Application.UseCases.Commands.AddGame
{
    public class AddGameCommand : IRequest<GameInfoResponse>
    {
        public int MinesCount { get; }
        public int Row { get; }
        public int Col { get; }

        public AddGameCommand(int minesCount, int row, int col)
        {
            if (minesCount <= 0) throw new ArgumentException("Mines count must be greater than 0", nameof(minesCount));
            if (row < 2 || row > 30) throw new ArgumentException("Row must be between 2 and 30", nameof(row));
            if (col < 2 || col > 30) throw new ArgumentException("Column must be between 2 and 30", nameof(col));

            MinesCount = minesCount;
            Row = row;
            Col = col;
        }
    }
}
