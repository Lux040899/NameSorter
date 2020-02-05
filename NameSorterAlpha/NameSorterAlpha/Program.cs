using System;
using System.IO;
using System.Collections.Generic;

namespace NameSorterAlpha
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Name> names = new List<Name>();
            List<string> sortNameList = new List<string>();

            // Initialising the list of names
            foreach (string name in File.ReadLines(args[0]))
            {
                names.Add(new Name(name));
            }

            names.Sort();

            // Initialsiing the list of sorted names
            foreach (Name name in names)
            {
                Console.WriteLine(name.getName());
                sortNameList.Add(name.getName());
            }

            File.WriteAllLines("sorted-names-list.txt", sortNameList);
            Console.ReadKey();
        }

    }

}