using LogCorner.Hackaton.TennisPlayer.Domain;
using LogCorner.Hackaton.TennisPlayer.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogCorner.Hackaton.TennisPlayer.Application.Exceptions;

namespace LogCorner.Hackaton.TennisPlayer.Application
{
    public class PlayerUseCase : IGetPlayersUsesCase, IGetPlayerUsesCase, IDeletePlayerUsesCase
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
            if (result == null)
            {
                throw new PlayerNotFoundException($"player with id = {playerRequest.Id} does not exist");
            }
            return result;
        }

        public async Task Handle(DeletePlayerCommand deletePlayerCommand)
        {
            if (deletePlayerCommand == null)
            {
                throw new ArgumentNullApplicationException(nameof(deletePlayerCommand));
            }
            var player = Repo.GetAsync(deletePlayerCommand.Id);
            if (player == null)
            {
                throw new PlayerNotFoundException($"player with id = {deletePlayerCommand.Id} does not exist");
            }
            await Repo.DeleteAsync(deletePlayerCommand.Id);
        }
    }
}