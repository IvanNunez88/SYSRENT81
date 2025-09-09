using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SYSRENT.Application.Data;

namespace SYSRENT.Infrastructure.Context;

public class SqlDapperConnection(IConfiguration _configuration) : ISqlDbConnection
{
    public IDbConnection GetConnection()
    {
        var ConnectionString = _configuration.GetConnectionString("SQL") ?? throw new Exception("");

        var _connection = new SqlConnection(ConnectionString);

        if (_connection.State != ConnectionState.Open)
        {
            _connection.Open();
        }

        return _connection;
    }
}
