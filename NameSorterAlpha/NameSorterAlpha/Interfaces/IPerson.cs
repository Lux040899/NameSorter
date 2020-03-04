using System;
using System.Threading.Tasks;

namespace NameSorter
{
    public interface IPerson
    {
        DateTime GetDate();
        string GetGivenName();
        string GetLastName();
        string GetName();
        void Initialise(string info, int lineCount);
        Task InitialiseGender();
    }
}