using LogCorner.Hackaton.TennisPlayer.Domain;
using LogCorner.Hackaton.TennisPlayer.Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Player>> GetAsync()
        {
            var players = _db.GetPlayers();

            return await Task.FromResult(players);
        }

        public async Task<Player> GetAsync(int id)
        {
            var players = _db.GetPlayers();
            var player = players.FirstOrDefault(p => p.Id == id);
            return await Task.FromResult(player); ;
        }

        public async Task DeleteAsync(int id)
        {
            var players = _db.GetPlayers();
            var player = players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                throw new PlayerNotFoundException($"player with id = {id} does not exist");
            }

            players.Remove(player);

            _db.WriteDataToJson(players);
            await Task.FromResult(players);
        }
    }
}