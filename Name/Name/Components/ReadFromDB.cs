using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name
{
    class ReadFromDB : IRead
    {
        public List<Name> ReadData(string connectionString)
        {
            List<Name> unsortedNames = new List<Name>();
            try
            {
                SqlConnection cnn;
                cnn = new SqlConnection(connectionString);
                cnn.Open();

                SqlCommand command;
                SqlDataReader dataReader;
                string sql = "Select FirstName, LastName from UnsortedName";

                command = new SqlCommand(sql, cnn);

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    unsortedNames.Add(new Name(dataReader.GetString(0), dataReader.GetString(1)));
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Unable to access the DataBase");
            }

            return unsortedNames;
        }
    }
}
