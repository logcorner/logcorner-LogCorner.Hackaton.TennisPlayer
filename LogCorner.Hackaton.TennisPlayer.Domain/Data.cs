namespace LogCorner.Hackaton.TennisPlayer.Domain
{
    public class Data
    {
        public int Rank { get; }
        public int Points { get; }
        public int Weight { get; }
        public int Height { get; }
        public int Age { get; }
        public int[] Last { get; }

        public Data(int rank, int points, int weight, int height, int age, int[] last)
        {
            Rank = rank;
            Points = points;
            Weight = weight;
            Height = height;
            Age = age;
            Last = last;
        }
    }
}