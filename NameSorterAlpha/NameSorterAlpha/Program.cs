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
            int personCount = 0;
            int lineCount = 0;
            int missingInfoCount = 0;


            try
            {
                foreach (string info in File.ReadLines(args[0]))
                {
                    try
                    {
                        lineCount += 1;
                        people.Add(new Person(info));
                        personCount += 1;
                    }
                    catch (MissingPersonException)
                    {
                        Console.WriteLine("The person in line " + lineCount + " is missing all of their information.");
                    }
                    catch (MissingLastNameException)
                    {
                        missingInfoCount += 1;
                        Console.WriteLine("The person in line " + lineCount + " with info, " +
                            info + " is missing his/her Last Name.");
                    }
                    catch (MissingBDayException)
                    {
                        missingInfoCount += 1;
                        Console.WriteLine("The person in line " + lineCount + " with info, " +
                            info + " is missing his/her Birthday.");
                    }
                }

            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine($"[Data File Missing] {e}");
                Console.ReadKey();                
            }
     
            if (missingInfoCount > 0) {
                Console.WriteLine("Press any key to sort the remaining people according to their last name\n");
                Console.ReadKey();
                Console.WriteLine();
            }

            people = people.OrderBy(person => person.GetLastName()).ThenBy(person => person.GetGivenName()).
                ThenBy(person => person.GetDate()).ToList();


            foreach (Person person in people)
            {
                Console.WriteLine(person.GetName());
                sortPersonList.Add(person.GetName());
            }

            File.WriteAllLines("sorted-names-list.txt", sortPersonList);
            Console.ReadKey();
        }

    }

}