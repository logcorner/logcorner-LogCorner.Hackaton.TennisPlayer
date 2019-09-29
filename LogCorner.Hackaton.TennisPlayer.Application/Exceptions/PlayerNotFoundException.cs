namespace LogCorner.Hackaton.TennisPlayer.Application.Exceptions
{
    public class PlayerNotFoundException : ApplicationException
    {
        public PlayerNotFoundException(string message) : base(message)
        {
        }
    }
}