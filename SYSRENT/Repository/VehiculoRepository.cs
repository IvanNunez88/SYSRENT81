using System.Data;
using Dapper;
using SYSRENT.Application.Contract;
using SYSRENT.Application.Data;
using SYSRENT.Domain.Vehiculo.DTO;
using SYSRENT.Domain.Vehiculo.Entity;

namespace SYSRENT.Infrastructure.Repository;

public class VehiculoRepository(ISqlDbConnection sqlDbConnection) : IVehiculoRepository
{
    public async Task<bool> ActualizarVehiculo(UPDVEHICULO Vehiculo)
    {
        bool Result = true;

        try
        {
            const string SQLScript = @"UPDATE VEHICULO SET Descrip = @P_Descrip,
                                                            IdTamaño = @P_IdTamano,
                                                            Capacidad = @P_Capacidad,
                                                            PRenta = @P_PRenta,
                                                            IsActivo = @P_IsActivo
                                        WHERE IdVehiculo = @P_IdVehiculo";
            var dpParametros = new
            {
                P_IdVehiculo = Vehiculo.IdVehiculo,
                P_Descrip = Vehiculo.Descrip,
                P_IdTamano = Vehiculo.IdTamaño,
                P_Capacidad = Vehiculo.Capacidad,
                P_PRenta = Vehiculo.PRenta,
                P_IsActivo = Vehiculo.IsEstado
            };

            using var Conn = sqlDbConnection.GetConnection();

            var rows = await Conn.ExecuteAsync(SQLScript, dpParametros, commandType: CommandType.Text);

            if (rows <= 0) Result = false;
        }
        catch
        {
            Result = false;
        }

        return Result;
    }

    public async Task<bool> AgregarVehiculo(VEHICULO Vehiculo)
    {
        bool Result = true;

        try
        {
            const string SQLScript = @"INSERT INTO VEHICULO(Descrip, IdTamaño,Capacidad, PRenta)
                                                      VALUES (@P_Descrip, @P_IdTamaño, @P_Capacidad, @P_PRenta)";
            var dpParametros = new
            {
                P_Descrip = Vehiculo.Descrip,
                P_IdTamaño = Vehiculo.IdTamaño,
                P_Capacidad = Vehiculo.Capacidad,
                P_PRenta = Vehiculo.PRenta
            };

            using var Conn = sqlDbConnection.GetConnection();

            var rows = await Conn.ExecuteAsync(SQLScript, dpParametros, commandType: CommandType.Text);

            if (rows <= 0) Result = false;
        }
        catch
        {
            Result = false;
        }

        return Result;
    }

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
