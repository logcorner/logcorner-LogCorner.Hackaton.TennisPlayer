namespace LogCorner.Hackaton.TennisPlayer.Infrastructure
{
    public interface IFileProvider
    {
        bool Exists(string fileName);

        string ReadAllText(string fullFilepath);

        void WriteAllText(string fullFilepath, string json);
    }
}