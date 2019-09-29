namespace LogCorner.Hackaton.TennisPlayer.Infrastructure
{
    public interface IFileProvider
    {
        bool Exists(string fileName);
    }
}