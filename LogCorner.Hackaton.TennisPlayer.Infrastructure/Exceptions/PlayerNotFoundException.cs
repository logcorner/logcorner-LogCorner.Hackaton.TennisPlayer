namespace LogCorner.Hackaton.TennisPlayer.Infrastructure.Exceptions
{
    public class PlayerNotFoundException : InfrastructureException
    {
        public PlayerNotFoundException(string message) : base(message)
        {
        }
    }
}