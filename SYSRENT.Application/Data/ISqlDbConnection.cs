using System.Data;

namespace SYSRENT.Application.Data;

public interface ISqlDbConnection
{
    IDbConnection GetConnection();
}
