using MediatR;
using SYSRENT.Application.Contract;
using SYSRENT.Application.Features.Vehiculo.Validator;
using SYSRENT.Domain;
using SYSRENT.Domain.Vehiculo.Entity;

namespace SYSRENT.Application.Features.Vehiculo.Command;

#region Command

public record AddVehiculoCommand(VEHICULO Vehiculo) : IRequest<DtoResponse<IEnumerable<string>>>;

#endregion

#region Handler

public class AddVehiculoCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<AddVehiculoCommand, DtoResponse<IEnumerable<string>>>
{
    public async Task<DtoResponse<IEnumerable<string>>> Handle(AddVehiculoCommand request, CancellationToken cancellationToken)
    {
        DtoResponse<IEnumerable<string>> rsp = new();
        VehiculoValidator Validaciones = new(_unitOfWork);

        var validationResult = await Validaciones.ValidateAsync(request.Vehiculo, cancellationToken);
        IEnumerable<string>? enuResultado = validationResult.Errors.Select(x => x.ErrorMessage);

        if (!enuResultado.Any())
        {
            if (await _unitOfWork.VehiculoRepository.AgregarVehiculo(request.Vehiculo))
            {
                rsp.Status = true;
            }
            else
            {
                rsp.Status = false;
            }
        }
        else
        {
            rsp.Status = false;
            rsp.Msg = enuResultado.ToList()[0];
        }

        return rsp;
    }
}

#endregion