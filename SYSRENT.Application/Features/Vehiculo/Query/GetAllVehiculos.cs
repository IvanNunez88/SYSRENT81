using MediatR;
using SYSRENT.Application.Contract;
using SYSRENT.Domain;
using SYSRENT.Domain.Vehiculo.DTO;

namespace SYSRENT.Application.Features.Vehiculo.Query;

#region Query
public record GetAllVehiculosQuery : IRequest<DtoResponse<IEnumerable<DtoConsultaVehiculo>>>;

#endregion

#region Handler

public class GetAllVehiculosQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAllVehiculosQuery, DtoResponse<IEnumerable<DtoConsultaVehiculo>>>
{
    public async Task<DtoResponse<IEnumerable<DtoConsultaVehiculo>>> Handle(GetAllVehiculosQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<DtoConsultaVehiculo> enuDatos = await _unitOfWork.VehiculoRepository.ConsultaVehiculos();
        DtoResponse<IEnumerable<DtoConsultaVehiculo>> rsp = new();

        if (enuDatos.Any())
        {
            rsp.Status = true;
            rsp.Values = enuDatos;
        }
        else
        {
            rsp.Status = false;
            rsp.Msg = "No se encontro información";
        }

        return rsp;
    }
}

#endregion