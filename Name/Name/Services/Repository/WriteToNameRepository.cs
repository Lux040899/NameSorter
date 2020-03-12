using Name.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Name
{
    class PersonWriterRepository : IWrite
    {
        
        IPersonDataContext _personDataContext;
        public PersonWriterRepository(IPersonDataContext personDataContext)
        {
            _personDataContext = personDataContext;
        }

        public void WriteData(List<Name> sortedNames)
        {
            string sql = $"Insert Into SortedName ([FirstName], [LastName]) values";

            foreach (Name name in sortedNames)
            {
                sql += $" ('{name._firstName}' , '{name._lastName}'),";
            }
            sql = sql.TrimEnd(',');

            try
            {
                _personDataContext.ExecuteWriteQuery(sql);               
            }

            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }
    }
}
