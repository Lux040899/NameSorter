using Name.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Name
{
    class WriteToNameRepository : IWrite
    {
        
        IPersonDataContext _personDataContext;
        public WriteToNameRepository(IPersonDataContext personDataContext)
        {
            _personDataContext = personDataContext;
        }

        public void WriteData(List<Name> sortedNames)
        {
            try
            {
                string sql = $"Insert Into SortedName ([FirstName], [LastName]) values";

                foreach (Name name in sortedNames)
                {
                    sql += $" ('{name._firstName}' , '{name._lastName}'),";
                }
                sql = sql.TrimEnd(',');
                sql += ";";

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = _personDataContext.ExecuteQuery(sql);
                adapter.InsertCommand.ExecuteNonQuery();

                _personDataContext.CloseContext();
                adapter.Dispose();
            }

            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }
    }
}
