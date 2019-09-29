using LogCorner.Hackaton.TennisPlayer.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogCorner.Hackaton.TennisPlayer.Application
{
    public interface IGetPlayersUsesCase
    {
        Task<IEnumerable<Player>> Handle();
    }
}