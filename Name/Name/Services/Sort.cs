using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name
{
    class Sort : ISort
    {
        public List<Name> Sorting(List<Name> unsortedNames)
        {
            return unsortedNames = unsortedNames.OrderBy(Name => Name._lastName).ThenBy(Name => Name._firstName).ToList();
        }
    }    
}
