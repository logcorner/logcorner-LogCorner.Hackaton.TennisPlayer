using LogCorner.Hackaton.TennisPlayer.Domain;
using System.Collections.Generic;

namespace LogCorner.Hackaton.TennisPlayer.Infrastructure
{
    public interface IDatabaseProvider
    {
        List<Player> GetPlayers();

        void WriteDataToJson(List<Player> players);
    }
}