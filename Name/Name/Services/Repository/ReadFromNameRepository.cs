using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Name.Services;

namespace Name
{
    class ReadFromNameRepository : IRead
    {
        IPersonDataContext _personDataContext; 
        public ReadFromNameRepository (IPersonDataContext personDataContext)
        {
            _personDataContext = personDataContext;
        }
        public void ReadData(string connectionString, List<Name> unsortedNames)
        {
            try
            {                
                string sql = "Select FirstName, LastName from UnsortedName";
                SqlDataReader dataReader = _personDataContext.NewContext(connectionString, sql);

                while (dataReader.Read())
                {
                    unsortedNames.Add(new Name(dataReader.GetString(0), dataReader.GetString(1)));
                }

                _personDataContext.CloseContext();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
