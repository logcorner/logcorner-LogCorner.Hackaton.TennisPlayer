using System.Collections.Generic;
using LogCorner.Hackaton.TennisPlayer.Domain;

namespace LogCorner.Hackaton.TennisPlayer.Infrastructure
{
    public interface IJsonProvider
    {
        List<Player> DeserializeObject(string json);
        string SerializeObject(List<Player> players);
    }
}