﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name
{
    class WriteToDB : IWrite
    {
        public void WriteData(string connectionString, List<Name> sortedNames)
        {
            try
            {
                SqlConnection cnn;
                cnn = new SqlConnection(connectionString);
                cnn.Open();

                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql;

                sql = $"Insert Into SortedName ([FirstName], [LastName]) values";

                foreach (Name name in sortedNames)
                {
                    sql += $" ('{name._firstName}' , '{name._lastName}'),";
                }
                sql = sql.TrimEnd(',');
                sql += ";";

                //Console.WriteLine(sql);

                command = new SqlCommand(sql, cnn);
                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }
    }
}