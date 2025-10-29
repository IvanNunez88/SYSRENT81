using MediatR;
using SYSRENT.Application.Contract;
using SYSRENT.Domain;
using SYSRENT.Domain.Horario.DTO;

namespace SYSRENT.Application.Features.Horario.Query;

#region Query
public class GetCatHorarioQuery : IRequest<DtoResponse<IEnumerable<DtoConsulCatHorario>>>;

#endregion

#region Handler
public class GetCatHorarioQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetCatHorarioQuery, DtoResponse<IEnumerable<DtoConsulCatHorario>>>
{
    public async Task<DtoResponse<IEnumerable<DtoConsulCatHorario>>> Handle(GetCatHorarioQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<DtoConsulCatHorario> enuDatos = await _unitOfWork.HorarioRepository.CatHorario();
        DtoResponse<IEnumerable<DtoConsulCatHorario>> rsp = new();

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