using System.Collections.Generic;
using System.Linq;

namespace NameSorter
{
    class SorterDescending : ISorter
    {
        public List<Person> Sort(List<Person> people)
        {
            return people = people.OrderByDescending(person => person.GetLastName()).ThenByDescending(person => person.GetGivenName()).
                    ThenByDescending(person => person.GetDate()).ToList();
        }
    }
}
