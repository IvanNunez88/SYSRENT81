using Dapper;
using SYSRENT.Application.Contract;
using SYSRENT.Application.Data;
using SYSRENT.Domain.Vehiculo.DTO;

namespace SYSRENT.Infrastructure.Repository;

public class VehiculoRepository(ISqlDbConnection sqlDbConnection) : IVehiculoRepository
{
    public async Task<IEnumerable<DtoConsultaVehiculo>> ConsultaVehiculos()
    {
        const string SQLScript = @"SELECT VEH.IdVehiculo,
                                    UPPER(VEH.Descrip) AS Vehiculo,
                                    VEH.IdTamaño as IdTamano,
                                    TAM.Tamano,
                                    VEH.Capacidad,
                                    VEH.PRenta,
                                    VEH.IsActivo,
                                    IIF(VEH.IsActivo= 1, 'ACTIVO', 'INACTIVO') AS Estatus
                            FROM VEHICULO AS VEH
                                INNER JOIN (SELECT IdTamaño,
                                                UPPER(Descrip) AS Tamano
                                            FROM TAMAÑO) AS TAM ON VEH.IdTamaño = TAM.IdTamaño";

        using var conn = sqlDbConnection.GetConnection();

        IEnumerable<DtoConsultaVehiculo> enuDato = (await conn.QueryAsync<DtoConsultaVehiculo>(SQLScript)).OrderBy(x => x.Vehiculo);

        return enuDato;
    }
}
