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
        public List<Name> ReadData(string filePath)
        {
            List<Name> unsortedNames = new List<Name>();
            foreach (string name in File.ReadLines(filePath))
            {
                unsortedNames.Add(new Name(new NameParser(name)));
            }
            return unsortedNames;
        }
    }
}
