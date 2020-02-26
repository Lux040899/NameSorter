using System;

namespace NameSorter
{
    class MissingDataException : Exception
    {
        public MissingDataException() { }

        public MissingDataException(string message)
            : base(message)
        {
        }

        public MissingDataException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
