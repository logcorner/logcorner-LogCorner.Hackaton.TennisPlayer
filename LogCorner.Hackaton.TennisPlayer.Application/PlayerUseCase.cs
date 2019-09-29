using LogCorner.Hackaton.TennisPlayer.Domain;
using LogCorner.Hackaton.TennisPlayer.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogCorner.Hackaton.TennisPlayer.Application
{
    public class PlayerUseCase : IGetPlayersUsesCase
    {
        private IPlayerRepository Repo { get; }

        public PlayerUseCase(IPlayerRepository repo)
        {
            Repo = repo;
        }

        public async Task<IEnumerable<Player>> Handle()
        {
            var result = await Repo.GetAsync();

            return result;
        }
    }
}