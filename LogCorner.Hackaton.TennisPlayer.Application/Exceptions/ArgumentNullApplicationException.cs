namespace LogCorner.Hackaton.TennisPlayer.Application.Exceptions
{
    public class ArgumentNullApplicationException : ApplicationException
    {
        public ArgumentNullApplicationException(string message) : base(message)
        {
        }
    }
}