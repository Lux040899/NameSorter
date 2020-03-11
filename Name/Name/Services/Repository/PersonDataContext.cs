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
        SqlConnection _cnn;
        SqlCommand _command;
        SqlDataReader _dataReader;

        public SqlDataReader NewContext(string connectionString, string sql)
        {
            try
            {
                _cnn = new SqlConnection(connectionString);
                _cnn.Open();
                _command = new SqlCommand(sql, _cnn);
                _dataReader = _command.ExecuteReader();                
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return _dataReader;
        }

        public void CloseContext()
        {
            _cnn.Close();
            _command.Dispose();
            _dataReader.Close();
        }
    }
}
