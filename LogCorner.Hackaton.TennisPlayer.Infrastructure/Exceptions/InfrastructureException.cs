using System;

namespace LogCorner.Hackaton.TennisPlayer.Infrastructure.Exceptions
{
    public class InfrastructureException : Exception
    {
        protected InfrastructureException(string message) : base(message)
        {
        }
    }
}
