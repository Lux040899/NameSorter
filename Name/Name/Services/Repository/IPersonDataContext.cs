using System.Data.SqlClient;

namespace Name.Services
{
    interface IPersonDataContext
    {
        SqlCommand ExecuteQuery(string sql);
        void CloseContext();
    }
}