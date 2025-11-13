using SYSRENT.Domain.Tamano.DTO;

namespace SYSRENT.Application.Contract;

public interface ITamanoRepository
{
    public Task<IEnumerable<DtoCatTamano>> ConsultaCatTamano();
}
