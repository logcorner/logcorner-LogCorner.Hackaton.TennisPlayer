using LogCorner.Hackaton.TennisPlayer.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogCorner.Hackaton.TennisPlayer.Infrastructure
{
    public class JsonPlayerRepository : IPlayerRepository
    {
        private readonly IDatabaseProvider _db;

        public JsonPlayerRepository(IDatabaseProvider db)
        {
            _db = db;
        }

        public async Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Player>> GetAsync()
        {
            var players = _db.GetPlayers();

            return await Task.FromResult(players);
        }

        public Task<Player> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}