using SYSRENT.Domain.Vehiculo.DTO;
using SYSRENT.Domain.Vehiculo.Entity;

namespace SYSRENT.Application.Contract;

public interface IVehiculoRepository
{
    public Task<IEnumerable<DtoConsultaVehiculo>> ConsultaVehiculos();
    public Task<bool> AgregarVehiculo(VEHICULO Vehiculo);
    public Task<bool> ActualizarVehiculo(UPDVEHICULO Vehiculo);
}
