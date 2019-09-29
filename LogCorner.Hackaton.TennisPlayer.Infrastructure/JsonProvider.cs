using System.Collections.Generic;
using LogCorner.Hackaton.TennisPlayer.Domain;
using Newtonsoft.Json;

namespace LogCorner.Hackaton.TennisPlayer.Infrastructure
{
    public class JsonProvider : IJsonProvider
    {
        public List<Player> DeserializeObject(string json)
        {
            return JsonConvert.DeserializeObject<List<Player>>(json);
        }

        public string SerializeObject(List<Player> players)
        {
            return  JsonConvert.SerializeObject(players, Formatting.Indented);
        }
    }
}