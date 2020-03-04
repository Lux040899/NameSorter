﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace NameSorter
{
    public interface IRead
    {
        List<Task> ReadData(string[] args, List<Person> people);
    }
}
