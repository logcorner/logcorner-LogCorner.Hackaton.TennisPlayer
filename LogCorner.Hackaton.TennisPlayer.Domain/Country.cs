namespace LogCorner.Hackaton.TennisPlayer.Domain
{
    public class Country
    {
        public string Picture { get; }
        public string Code { get; }

        public Country(string picture, string code)
        {
            Picture = picture;
            Code = code;
        }
    }
}