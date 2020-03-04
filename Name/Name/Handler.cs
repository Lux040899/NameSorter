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

        public void Start(string filePath)
        {
            List<Name> unsortedNames = _readNames.ReadData(filePath);
            List<Name> sortedNames = _sorter.Sorting(unsortedNames);
            _outputNames.ConsoleOutput(sortedNames);           
        }
    }
}
