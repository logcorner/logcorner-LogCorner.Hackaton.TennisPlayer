using System.Collections.Generic;
using LogCorner.Hackaton.TennisPlayer.Domain;
using LogCorner.Hackaton.TennisPlayer.Infrastructure.Exceptions;
using Microsoft.Extensions.Configuration;

namespace LogCorner.Hackaton.TennisPlayer.Infrastructure
{
    public class JsonDatabaseProvider : IDatabaseProvider
    {
        private readonly IConfiguration _configuration;
        private readonly IFileProvider _fileProvider;
        private readonly IJsonProvider _jsonProvider;

        public JsonDatabaseProvider(IConfiguration configuration, IFileProvider fileProvider , IJsonProvider jsonProvider)
        {
            _configuration = configuration;
            _fileProvider = fileProvider;
            _jsonProvider = jsonProvider;
        }

        private string GetConnectionString()
        {
            var fullFilePath = _configuration["ConnectionStrings:FullFilePath"];

            if (!_fileProvider.Exists(fullFilePath))
            {
                throw new FilePathNotFoundException($"file not found {fullFilePath}");
            }
            return fullFilePath;
        }

        public List<Player> GetPlayers()
        {
            var json = _fileProvider.ReadAllText(GetConnectionString());
            var players = _jsonProvider.DeserializeObject(json);
            return players;
        }

        public void WriteDataToJson(List<Player> players)
        {
            if (players == null)
            {
                throw new NullPlayersException(nameof(players));
            }
            var json = _jsonProvider.SerializeObject(players);
            _fileProvider.WriteAllText(GetConnectionString(), json);
        }
    }
}