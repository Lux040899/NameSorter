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
            int person_count = 0;
            int missing_info_count = 0;

            foreach (string info in File.ReadLines(args[0]))
            {
                try
                {
                    person_count += 1;
                    people.Add(new Person(info, person_count));
                }
                catch (MissingLastNameException)
                {
                    missing_info_count += 1;
                    Console.WriteLine("The person in line " + person_count + " with info, " +
                        info + " is missing his/her Last Name.");
                }
                catch (MissingBDayException)
                {
                    missing_info_count += 1;
                    Console.WriteLine("The person in line " + person_count + " with info, " +
                        info + " is missing his/her Birthday.");
                }
            }

            if (missing_info_count > 0)
            {
                Console.ReadKey();
                return;
            }

            people = people.OrderBy(person => person.LastName).ThenBy(person => person.GivenNames).ThenBy(person => person._dateOfBirth)
                .ToList();


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