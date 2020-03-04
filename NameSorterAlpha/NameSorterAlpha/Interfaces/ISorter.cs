using System.Collections.Generic;

namespace NameSorter
{
    interface ISorter
    {
        IList<IPerson> Sort(IList<IPerson> people);
    }
}
