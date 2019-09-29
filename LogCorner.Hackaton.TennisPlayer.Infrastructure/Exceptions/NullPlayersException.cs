namespace LogCorner.Hackaton.TennisPlayer.Infrastructure.Exceptions
{
    internal class NullPlayersException : InfrastructureException
    {
        public NullPlayersException(string message) : base(message)
        {
        }
    }
}