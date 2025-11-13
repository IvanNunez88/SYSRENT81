using MediatR;
using SYSRENT.Application.Contract;
using SYSRENT.Domain;
using SYSRENT.Domain.Tamano.DTO;

namespace SYSRENT.Application.Features.Tamaño.Query;

#region Query
public record GetCatTamañoQuery : IRequest<DtoResponse<IEnumerable<DtoCatTamano>>>;

#endregion


#region Handler
public class GetCatTamañoQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetCatTamañoQuery, DtoResponse<IEnumerable<DtoCatTamano>>>
{
    public async Task<DtoResponse<IEnumerable<DtoCatTamano>>> Handle(GetCatTamañoQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<DtoCatTamano> enuDatos = await _unitOfWork.TamanoRepository.ConsultaCatTamano();
        DtoResponse<IEnumerable<DtoCatTamano>> rsp = new();

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