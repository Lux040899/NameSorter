using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    class SorterAscending : ISorter
    {
        public IList<IPerson> Sort(IList<IPerson> people)
        {
            return people = people.OrderBy(person => person.GetLastName()).ThenBy(person => person.GetGivenName()).
                    ThenBy(person => person.GetDate()).ToList();
        }
    }
}
