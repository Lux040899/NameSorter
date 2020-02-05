using System;

namespace NameSorter 
{
    public class AlternateName : IComparable<AlternateName>
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
            int name_len = reversed_name.Length - 1;
            reversed_name = reversed_name.Substring(0, name_len);
        }

        public int CompareTo(AlternateName other)
        {
            return reversed_name.CompareTo(other.reversed_name);
        }

        public string getName()
        {
            return name;
        }

        public string getReversedName()
        {
            return reversed_name;
        }
    }
}
