using System;

namespace NameSorter
{
    class MissingBDayException : Exception
    {
        public MissingBDayException() { }

        public MissingBDayException(string message)
            : base(message)
        {
        }

        public MissingBDayException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
