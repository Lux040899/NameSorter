using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter  
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<string> sortPersonList = new List<string>();
            int line_count = 0;

            foreach (string info in File.ReadLines(args[0]))
            {
                try
                {
                    line_count += 1;
                    people.Add(new Person(info, line_count));
                }
                catch (MissingInfoException)
                {
                    Console.WriteLine("The person in line " + line_count + " is missing information.\n");
                }
            }

            people = people.OrderBy(person => person.LastName).ThenBy(person => person.GivenNames).ToList();


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