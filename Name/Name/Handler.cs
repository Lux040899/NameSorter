using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name
{
    class Handler : IHandler
    {
        IRead _readNames;
        IOutput _outputNames;
        ISort _sorter;

        public Handler(IRead readNames, IOutput outputNames, ISort sorter)
        {
            _readNames = readNames;
            _sorter = sorter;
            _outputNames = outputNames;
        }

        public void Start(string source)
        {
            List<Name> unsortedNames = _readNames.ReadData(source);
            List<Name> sortedNames = _sorter.Sorting(unsortedNames);
            Write.WriteData(source, sortedNames);
            _outputNames.ConsoleOutput(sortedNames);            
        }
    }
}
