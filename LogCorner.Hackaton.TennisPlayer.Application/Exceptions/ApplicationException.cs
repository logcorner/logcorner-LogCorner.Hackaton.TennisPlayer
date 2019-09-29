using System;

namespace LogCorner.Hackaton.TennisPlayer.Application.Exceptions
{
    public class ApplicationException : Exception
    {
        protected ApplicationException(string message) : base(message)
        {
        }
    }
}