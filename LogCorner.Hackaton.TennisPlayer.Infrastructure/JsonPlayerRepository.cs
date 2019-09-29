using LogCorner.Hackaton.TennisPlayer.Domain;
using LogCorner.Hackaton.TennisPlayer.Infrastructure.Exceptions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LogCorner.Hackaton.TennisPlayer.Infrastructure
{
    public class JsonPlayerRepository : IPlayerRepository
    {
        private readonly IConfiguration _configuration;

        public JsonPlayerRepository( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            var fullFilePath = _configuration["ConnectionStrings:FullFilePath"];

            if (!File.Exists(fullFilePath))
            {
                throw new FilePathNotFoundException($"file not found {fullFilePath}");
            }
            return fullFilePath;
        }

        private List<Player> GetPlayers()
        {
            var json = File.ReadAllText(GetConnectionString());
            var players = JsonConvert.DeserializeObject<List<Player>>(json);
            return players;
        }

        public async Task DeleteAsync(int id)
        {
            var players = GetPlayers();
            var player = players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                throw new PlayerNotFoundException($"player with id = {id} does not exist");
            }

            players.Remove(player);

            WriteDataToJson(players);
            await Task.FromResult(players);
        }

        public async Task<IEnumerable<Player>> GetAsync()
        {
            var players = GetPlayers();

            return await Task.FromResult(players);
        }

        public async Task<Player> GetAsync(int id)
        {
            var players = GetPlayers();
            var player = players.FirstOrDefault(p => p.Id == id);
            return await Task.FromResult(player); ;
        }

        private void WriteDataToJson(List<Player> players)
        {
            if (players == null)
            {
                throw new NullPlayersException(nameof(players));
            }
            var json = JsonConvert.SerializeObject(players, Formatting.Indented);
            File.WriteAllText(GetConnectionString(), json);
        }
    }
}