using System;

namespace NameSorter
{
    class MissingPersonException : Exception
    {
        public MissingPersonException() { }

        public MissingPersonException(string message)
            : base(message)
        {
        }

        public MissingPersonException(string message, Exception inner)
            : base(message, inner)
        { 
        }
    }
}
