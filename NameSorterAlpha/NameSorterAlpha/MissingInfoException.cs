using System;

namespace NameSorter
{
    class MissingLastNameException : Exception
    {
        public MissingLastNameException() { }


        public MissingLastNameException(string message)
            : base(message)
        {
        }

        public MissingLastNameException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
