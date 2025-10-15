using SYSRENT.Domain.Horario.DTO;
using SYSRENT.Domain.Horario.Entity;

namespace SYSRENT.Application.Contract;

public interface IHorarioRepository
{
    public Task<bool> AgregarHorario(HORARIO Horario);
    public Task<IEnumerable<DtoConsulCatHorario>> CatHorario();


}
