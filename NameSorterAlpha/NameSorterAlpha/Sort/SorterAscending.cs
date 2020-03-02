using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    class SorterAscending : ISorter
    {
        public List<Person> Sort(List<Person> people)
        {
            return people = people.OrderBy(person => person.GetLastName()).ThenBy(person => person.GetGivenName()).
                    ThenBy(person => person.GetDate()).ToList();
        }
    }
}
