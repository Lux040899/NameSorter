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
        SqlDataReader _dataReader;

        public PersonDataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlCommand ExecuteQuery(string sql)
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

        public void CloseContext()
        {
            _cnn.Close();
            _command.Dispose();
        }
    }
}
