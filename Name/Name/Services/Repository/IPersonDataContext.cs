using System.Collections.Generic;
using System.Data.SqlClient;

namespace Name.Services
{
    interface IPersonDataContext
    {
        SqlCommand GetCommand(string sql);
        List<Name> ExecuteReadQuery(string sql);
        void ExecuteWriteQuery(string sql);
        void CloseContext();
    }
}