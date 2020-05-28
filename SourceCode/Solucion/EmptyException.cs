using System;

namespace Solucion
{
    public class EmptyException : Exception
    {
        public EmptyException(string message) : base(message)
        {
        }
    }
}