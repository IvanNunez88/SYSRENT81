using System.Data;
using Dapper;
using SYSRENT.Application.Contract;
using SYSRENT.Application.Data;
using SYSRENT.Domain.Horario.DTO;
using SYSRENT.Domain.Horario.Entity;

namespace SYSRENT.Infrastructure.Repository;

public class HorarioRepository(ISqlDbConnection sqlDbConnection) : IHorarioRepository
{
    private static readonly string DefaultCatalog = "[SELECCIONAR]";

    public async Task<bool> AgregarHorario(HORARIO Horario)
    {
        bool Result = true;

        try
        {
            const string SQLScript = @"INSERT INTO HORARIO (Descrip, Minutos) 
                                                     VALUES (@P_Descrip, @P_Minutos)";

            var dpParametros = new
            {
                @P_Descrip = Horario.Descrip,
                @P_Minutos = Horario.Minutos
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

    public async Task<IEnumerable<DtoConsulCatHorario>> CatHorario()
    {
        List<DtoConsulCatHorario> lstDatos = [new DtoConsulCatHorario(IdHorario: 0, Descrip: DefaultCatalog, Minutos: 0)];

        const string SQLScript = @"SELECT IdHorario,
                                            Descrip,
                                            Minutos
                                    FROM HORARIO";

        using var Conn = sqlDbConnection.GetConnection();

        IEnumerable<DtoConsulCatHorario> enuDatos = (await Conn.QueryAsync<DtoConsulCatHorario>(SQLScript, null, commandType: CommandType.Text)).OrderBy(x => x.Minutos);

        lstDatos.AddRange(enuDatos);

        return lstDatos;
    }
}
