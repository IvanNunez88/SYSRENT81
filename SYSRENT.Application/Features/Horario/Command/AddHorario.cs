using MediatR;
using SYSRENT.Application.Contract;
using SYSRENT.Application.Features.Horario.Validator;
using SYSRENT.Domain;
using SYSRENT.Domain.Horario.Entity;

namespace SYSRENT.Application.Features.Horario.Command;

#region Command
public record AddHorarioCommand(HORARIO Horario) : IRequest<DtoResponse<IEnumerable<string>>>;

#endregion

#region Handler

public class AddHorarioCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<AddHorarioCommand, DtoResponse<IEnumerable<string>>>
{
    public async Task<DtoResponse<IEnumerable<string>>> Handle(AddHorarioCommand request, CancellationToken cancellationToken)
    {
        DtoResponse<IEnumerable<string>> rsp = new();
        HorarioValidator Validaciones = new(_unitOfWork);

        var validationResult = await Validaciones.ValidateAsync(request.Horario, cancellationToken);
        IEnumerable<string>? enuResultado = validationResult.Errors.Select(x => x.ErrorMessage);

        if (!enuResultado.Any())
        {
            if (await _unitOfWork.HorarioRepository.AgregarHorario(request.Horario))
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