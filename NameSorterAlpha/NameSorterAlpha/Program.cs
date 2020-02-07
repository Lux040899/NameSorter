using System;
using System.IO;
using System.Collections.Generic;

namespace NameSorter
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<string> sortPersonList = new List<string>();

            foreach (string info in File.ReadLines(args[0]))
            {
                people.Add(new Person(info));
            }

            people = people.Sort(person => person.LastName).ThenBy(person => person.GivenNames);


            foreach (Person person in people)
            {
                Console.WriteLine(person.getName());
                sortPersonList.Add(person.getName());
            }

            File.WriteAllLines("sorted-names-list.txt", sortPersonList);
            Console.ReadKey();
        }

    }

}