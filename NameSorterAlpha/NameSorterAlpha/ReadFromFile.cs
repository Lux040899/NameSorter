using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NameSorter
{
    class ReadFromFile : IRead
    {
        public List<Task> setAllGenders = new List<Task>();

        public List<Task> ReadData(string[] args, List<Person> people)
        {
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

                if (missingInfoCount > 0)
                {
                    Console.Write("Press any key to sort the remaining people according to their last name:");
                    Console.ReadKey();
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"[Data File Missing] {e}");
                Console.ReadKey();
            }

            return setAllGenders;
        }
    }
}
