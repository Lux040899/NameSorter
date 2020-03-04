using System.Threading.Tasks;

namespace NameSorter
{
    interface ISetGender
    {
        string GetGender();
        Task SetFinalGender(string name);
    }
}