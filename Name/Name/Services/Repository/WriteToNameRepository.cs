using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Name
{
    class WriteToNameRepository : IWrite
    {
        public void WriteData(string connectionString, List<Name> sortedNames)
        {
            try
            {
                SqlConnection cnn;
                cnn = new SqlConnection(connectionString);
                cnn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql;

                sql = $"Insert Into SortedName ([FirstName], [LastName]) values";

                foreach (Name name in sortedNames)
                {
                    sql += $" ('{name._firstName}' , '{name._lastName}'),";
                }
                sql = sql.TrimEnd(',');
                sql += ";";

                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }
    }
}
