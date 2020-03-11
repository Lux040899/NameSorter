using System.Data.SqlClient;

namespace Name.Services
{
    interface IPersonDataContext
    {
        SqlDataReader NewContext(string connectionString, string sql);
        void CloseContext();
    }
}