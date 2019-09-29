using System.IO;

namespace LogCorner.Hackaton.TennisPlayer.Infrastructure
{
    public class FileProvider : IFileProvider
    {
        public bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }

        public string ReadAllText(string fullFilepath)
        {
            return File.ReadAllText(fullFilepath);
        }

        public void WriteAllText(string fullFilepath, string json)
        {
            File.WriteAllText(fullFilepath, json);
        }
    }
}