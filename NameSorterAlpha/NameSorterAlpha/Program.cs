using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NameSorter  
{
    class Program
    {
        private static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<string> sortPersonList = new List<string>();
            IRead read = Factory.CreateReader();
            IWrite write = Factory.CreateWriter();
            ISorter sorter;

            List<Task> setAllGenders = read.ReadData(args, people);

            Console.Write("Press 1 to sort the names in ascending order or press 2 to sort the names in descending order: ");

            int sorting_way = Convert.ToInt32(Console.ReadLine());

            while (sorting_way != 1 && sorting_way != 2)
            {
                Console.Write("Incorrect Input, please choose again: ");
                sorting_way = Convert.ToInt32(Console.ReadLine());
            }

            sorter = Factory.CreateSorter(sorting_way);

            people = sorter.Sort(people);

            Task.WhenAll(setAllGenders).Wait();

            foreach (Person person in people)
            {
                Console.WriteLine(person.GetName());
                sortPersonList.Add(person.GetName());
            }

            write.WriteData(sortPersonList);
            Console.ReadKey();
        }
    }
}