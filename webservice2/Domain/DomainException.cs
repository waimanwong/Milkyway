
using System;

namespace webservice2.Domain
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message) { }
    }
}