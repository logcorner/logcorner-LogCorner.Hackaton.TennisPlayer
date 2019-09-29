using System.Collections.Generic;
using LogCorner.Hackaton.TennisPlayer.Domain;

namespace LogCorner.Hackaton.TennisPlayer.Infrastructure
{
    public interface IDatabaseProvider
    {

        List<Player> GetPlayers();

        void WriteDataToJson(List<Player> players);
    }
}