namespace LogCorner.Hackaton.TennisPlayer.Domain
{
    public class Player
    {
        public int Id { get; }
        public string Firstname { get; }
        public string Lastname { get; }
        public string Sex { get; }
        public Country Country { get; }
        public string Picture { get; }
        public Data Data { get; }

        public Player(int id, string firstname, string lastname, string sex, Country country, string picture, Data data)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Sex = sex;
            Country = country;
            Picture = picture;
            Data = data;
        }
    }
}