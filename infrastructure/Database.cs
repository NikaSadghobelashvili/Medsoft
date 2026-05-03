using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Medbay.WinForms.Infrastructure;

internal static class Database
{
    public static SqlConnection CreateConnection()
    {
        var cs = ConfigurationManager.ConnectionStrings["Medbay"]?.ConnectionString
                  ?? throw new Exception("Connection string 'Medbay' is missing!");

        return new SqlConnection(cs);
    }
}
