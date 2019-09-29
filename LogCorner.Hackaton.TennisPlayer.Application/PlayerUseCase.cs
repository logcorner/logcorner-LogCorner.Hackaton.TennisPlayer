using LogCorner.Hackaton.TennisPlayer.Domain;
using LogCorner.Hackaton.TennisPlayer.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogCorner.Hackaton.TennisPlayer.Application.Exceptions;

namespace LogCorner.Hackaton.TennisPlayer.Application
{
    public class PlayerUseCase : IGetPlayersUsesCase, IGetPlayerUsesCase
    {
        private IPlayerRepository Repo { get; }

        public PlayerUseCase(IPlayerRepository repo)
        {
            Repo = repo;
        }

        public async Task<IEnumerable<Player>> Handle()
        {
            var result = await Repo.GetAsync();

            return result.OrderBy(r=>r.Id);
        }

        public async Task<Player> Handle(PlayerRequest playerRequest)
        {
            if (playerRequest == null)
            {
                throw new ArgumentNullApplicationException(nameof(playerRequest));
            }
            var result = await Repo.GetAsync(playerRequest.Id);

            return result;
        }
    }
}