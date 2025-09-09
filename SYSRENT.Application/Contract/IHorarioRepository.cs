using SYSRENT.Domain.Horario.DTO;

namespace SYSRENT.Application.Contract;

public interface IHorarioRepository
{

    public Task<IEnumerable<DtoConsulCatHorario>> CatHorario();

}
