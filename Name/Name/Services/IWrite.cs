using System.Collections.Generic;

namespace Name
{
    interface IWrite
    {
        void WriteData(string connectionString, List<Name> sortedNames);
    }
}