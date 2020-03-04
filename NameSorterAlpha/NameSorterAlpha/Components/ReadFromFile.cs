using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NameSorter
{
    class ReadFromFile : IRead
    {
       
       public List<IPerson> ReadData(string filePath, out List<Task> setAllGenders)
        {
            setAllGenders = new List<Task>();
            List<IPerson> people = new List<IPerson>();
            int lineCount = 0;
            int missingInfoCount = 0;

            try
            {
                foreach (string info in File.ReadLines(filePath))
                {
                    try
                    {
                        IPerson person = Factory.CreatePerson();
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

            return people;
        }
    }
}
