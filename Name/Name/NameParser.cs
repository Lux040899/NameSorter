using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name
{
    class NameParser : INameParser 
    {
        public string[] nameArray;
        public NameParser(string name)
        {
            nameArray = name.Split();
        }
    }
}
