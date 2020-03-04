using System.Collections.Generic;
using System.Linq;

namespace NameSorter
{
    class SorterDescending : ISorter
    {
        public IList<IPerson> Sort(IList<IPerson> people)
        {
            return people = people.OrderByDescending(person => person.GetLastName()).ThenByDescending(person => person.GetGivenName()).
                    ThenByDescending(person => person.GetDate()).ToList();
        }
    }
}
