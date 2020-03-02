using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
