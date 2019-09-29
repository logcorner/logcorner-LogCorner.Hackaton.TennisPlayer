namespace LogCorner.Hackaton.TennisPlayer.Infrastructure.Exceptions
{
    public class FilePathNotFoundException : InfrastructureException
    {
        public FilePathNotFoundException(string message) : base(message)
        {
        }
    }
}