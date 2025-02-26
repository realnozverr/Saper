using Application.Ports.GameCache;
using Domain.GameAggreagate;
using System.Collections.Concurrent;

namespace Infrastructure.Adapters.GameCache
{
    public class GameCache : IGameCache
    {
        private readonly ConcurrentDictionary<Guid, Game> _games = new ConcurrentDictionary<Guid, Game>();
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(10, 10);

        public async Task<Game> GetGame(Guid gameId)
        {
            await _semaphore.WaitAsync();
            try
            {
                return _games.TryGetValue(gameId, out var game) ? game : null;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task AddGame(Game game)
        {
            await _semaphore.WaitAsync();
            try
            {
                _games.TryAdd(game.Id, game);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task UpdateGame(Game game)
        {
            await _semaphore.WaitAsync();
            try
            {
                _games[game.Id] = game;
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
