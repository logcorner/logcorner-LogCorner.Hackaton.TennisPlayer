using System.Threading.Tasks;

namespace LogCorner.Hackaton.TennisPlayer.Application
{
    public interface IDeletePlayerUsesCase
    {
        Task Handle(DeletePlayerCommand deletePlayerCommand);
    }
}