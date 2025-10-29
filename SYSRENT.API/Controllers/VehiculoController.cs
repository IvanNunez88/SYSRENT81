using MediatR;
using Microsoft.AspNetCore.Mvc;
using SYSRENT.Application.Features.Vehiculo.Query;

namespace SYSRENT.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiculoController(IMediator _mediator) : ControllerBase
{

    [HttpGet("ListaVehiculos")]
    public async Task<IActionResult> ListaVehiculos()
    {
        return Ok(await _mediator.Send(new GetAllVehiculosQuery()));
    }

}
