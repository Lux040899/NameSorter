using System.Collections.Generic;
using System.Threading.Tasks;

namespace NameSorter
{
    public interface IRead
    {
       List<IPerson> ReadData(string filePath, out List<Task> setAllGenders);
       
    }
}
