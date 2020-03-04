using System.Collections.Generic;
using System.IO;

namespace NameSorter
{
    class WriteToFile : IWrite
    {
        public void WriteData(List<string> sortPersonList)
        {
            File.WriteAllLines("sorted-names-list.txt", sortPersonList);
        }
    }
}
