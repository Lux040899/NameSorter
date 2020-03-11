using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name
{
    class Application : IApplication
    {
        IHandler _handler;


        public Application(IHandler handler)
        {
            _handler = handler;
        }

        public void Run(string source)
        {
            _handler.Start(source);
        }
    }
}
