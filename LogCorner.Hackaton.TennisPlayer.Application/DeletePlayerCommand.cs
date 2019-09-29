namespace LogCorner.Hackaton.TennisPlayer.Application
{
    public class DeletePlayerCommand : ICommand
    {
        public readonly int Id;

        public DeletePlayerCommand(int id)
        {
            Id = id;
        }
    }
}