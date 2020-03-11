using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name
{
    class Output : IOutput
    {
        public void ConsoleOutput(List<Name> unsortedNames)
        {
            foreach (Name name in unsortedNames)
            {
                Console.WriteLine($"{name._firstName} {name._lastName}");
            }
            Console.ReadKey();
        }
    }
}
