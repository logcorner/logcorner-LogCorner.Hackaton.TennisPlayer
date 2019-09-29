using System;

namespace LogCorner.Hackaton.TennisPlayer.Application.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string message) : base(message)
        {
        }
    }
}