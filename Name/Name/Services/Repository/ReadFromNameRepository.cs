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
        public void ReadData(List<Name> unsortedNames)
        {
            try
            {                
                string sql = "Select FirstName, LastName from UnsortedName";
                SqlDataReader dataReader = _personDataContext.ExecuteQuery(sql).ExecuteReader(); 
                while (dataReader.Read())
                {
                    unsortedNames.Add(new Name(dataReader.GetString(0), dataReader.GetString(1)));
                }

                _personDataContext.CloseContext();
                dataReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
