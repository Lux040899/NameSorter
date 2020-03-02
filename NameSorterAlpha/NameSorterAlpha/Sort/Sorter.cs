using System.Collections.Generic;
using System.Linq;

namespace NameSorter
{
    interface ISorter
    {
        List<Person> Sort(List<Person> people);
    }
}
