using SYSRENT.Application.Contract;
using SYSRENT.Application.Data;
using SYSRENT.Domain.Horario.DTO;

namespace SYSRENT.Infrastructure.Repository;

public class HorarioRepository(ISqlDbConnection sqlDbConnection) : IHorarioRepository
{
    public Task<IEnumerable<DtoConsulCatHorario>> CatHorario()
    {
        throw new NotImplementedException();
    }
}
