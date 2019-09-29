using System;
using System.Collections.Generic;
using System.Text;

namespace LogCorner.Hackaton.TennisPlayer.Infrastructure.Exceptions
{
    public class InfrastructureException : Exception
    {
        protected InfrastructureException(string message) : base(message)
        {
        }
    }
}
