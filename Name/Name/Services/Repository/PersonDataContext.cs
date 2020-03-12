using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name.Services
{
    class PersonDataContext : IPersonDataContext
    {
        string _connectionString;
        SqlConnection _cnn;
        SqlCommand _command;

        public PersonDataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlCommand GetCommand(string sql)
        {
            try
            {
                _cnn = new SqlConnection(_connectionString);
                _cnn.Open();
                _command = new SqlCommand(sql, _cnn);                                
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return _command;
        }

        public List<Name> ExecuteReadQuery(string sql)
        {
            List<Name> unsortedNames = new List<Name>();
            SqlDataReader dataReader = GetCommand(sql).ExecuteReader();
            while (dataReader.Read())
            {
                unsortedNames.Add(new Name(dataReader.GetString(0), dataReader.GetString(1)));
            }

            CloseContext();
            dataReader.Close();
            return unsortedNames;
        }

        public void ExecuteWriteQuery(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter
            {
                InsertCommand = GetCommand(sql)
            };
            adapter.InsertCommand.ExecuteNonQuery();

            CloseContext();
            adapter.Dispose();
        }

        public void CloseContext()
        {
            _cnn.Close();
            _command.Dispose();
        }
    }
}
