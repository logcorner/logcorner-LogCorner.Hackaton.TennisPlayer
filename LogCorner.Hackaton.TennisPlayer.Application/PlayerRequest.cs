using LogCorner.Hackaton.TennisPlayer.Domain;
using System.Threading.Tasks;

namespace LogCorner.Hackaton.TennisPlayer.Application
{
    public class PlayerRequest : IRequest
    {
        public readonly int Id;

        public PlayerRequest(int id)
        {
            Id = id;
        }
    }

    public interface IGetPlayerUsesCase
    {
        Task<Player> Handle(PlayerRequest playerRequest);
    }
}