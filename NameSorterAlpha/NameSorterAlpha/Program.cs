using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NameSorter  
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> people = new List<Person>();
            List<string> sortPersonList = new List<string>();
            List<Task> setAllGenders = new List<Task>();
       
            int lineCount = 0;
            int missingInfoCount = 0;

            try
            {
                foreach (string info in File.ReadLines(args[0]))
                {
                    try
                    {
                        Person person = new Person();
                        lineCount += 1;                        
                        person.Initialise(info, lineCount);
                        people.Add(person);
                        setAllGenders.Add(person.InitialiseGender());                                        
                    }
                    catch (MissingDataException e)
                    {
                        missingInfoCount += 1;
                        Console.WriteLine($"{e}");
                    }
                }
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine($"[Data File Missing] {e}");
                Console.ReadKey();                
            }
     
            people = people.OrderBy(person => person.GetLastName()).ThenBy(person => person.GetGivenName()).
                ThenBy(person => person.GetDate()).ToList();

            foreach (Person person in people)
            {
                Console.WriteLine(person.GetName());
                sortPersonList.Add(person.GetName());
            }
           
            Task.WhenAll(setAllGenders).Wait();

            if (missingInfoCount > 0)
            {
                Console.Write("Press any key to sort the remaining people according to their last name:");
                Console.ReadKey();
            }

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