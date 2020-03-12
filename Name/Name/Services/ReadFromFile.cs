using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name
{
    class ReadFromFile : IRead
    {
        public void ReadData(List<Name> unsortedNames)
        {
            foreach (string name in File.ReadLines("Lol"))
            {
                unsortedNames.Add(new Name(new NameParser(name)));
            }            
        }
    }
}
