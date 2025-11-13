using System.Data;
using Dapper;
using SYSRENT.Application.Contract;
using SYSRENT.Application.Data;
using SYSRENT.Domain.Tamano.DTO;

namespace SYSRENT.Infrastructure.Repository;

public class TamanoRepository(ISqlDbConnection sqlDbConnection) : ITamanoRepository
{
    private static readonly string DefaultCatalogo = "[SELECCIONAR]";
    public async Task<IEnumerable<DtoCatTamano>> ConsultaCatTamano()
    {
        List<DtoCatTamano> lstDatos = [new DtoCatTamano(IdTamano: 0, Tamano: DefaultCatalogo)];

        const string SQLScript = @"SELECT IdTamaño AS IdTamano,
                                        UPPER(Descrip) AS Tamano
                                    FROM TAMAÑO";

        using var Conn = sqlDbConnection.GetConnection();

        IEnumerable<DtoCatTamano> enuDatos = (await Conn.QueryAsync<DtoCatTamano>(SQLScript, null, commandType: CommandType.Text)).OrderBy(x => x.Tamano);

        lstDatos.AddRange(enuDatos);

        return lstDatos;
    }
}
