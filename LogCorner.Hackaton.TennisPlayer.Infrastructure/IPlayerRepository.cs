using LogCorner.Hackaton.TennisPlayer.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogCorner.Hackaton.TennisPlayer.Infrastructure
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAsync();
    }
}