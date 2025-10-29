using SYSRENT.Domain.Vehiculo.DTO;

namespace SYSRENT.Application.Contract;

public interface IVehiculoRepository
{
    public Task<IEnumerable<DtoConsultaVehiculo>> ConsultaVehiculos();
}
