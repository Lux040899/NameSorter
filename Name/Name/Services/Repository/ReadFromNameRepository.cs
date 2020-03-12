using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Name.Services;

namespace Name
{
    class PersonReaderRepository : IRead
    {
        IPersonDataContext _personDataContext; 
        public PersonReaderRepository (IPersonDataContext personDataContext)
        {
            _personDataContext = personDataContext;

        }
        public List<Name> ReadData()
        {
            List<Name> unsortedNames = new List<Name>();
            string sql = "Select FirstName, LastName from UnsortedName";
           
            try
            {
                unsortedNames = _personDataContext.ExecuteReadQuery(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return unsortedNames;
        }
    }
}
