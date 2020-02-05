using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter 
{
    class AlternateName : IComparable<AlternateName>
    {
        private string name;
        private string reversed_name;

        public AlternateName(string name)
        {
            this.name = name;
            string[] nameArray = name.Split(' ');
            Array.Reverse(nameArray);
            foreach (string name_component in nameArray)
            {
                reversed_name += name_component;
                reversed_name += ' ';
            }
        }

        public int CompareTo(AlternateName other)
        {
            return this.reversed_name.CompareTo(other.reversed_name);
        }

        public string getName()
        {
            return this.name;
        }
    }
}
