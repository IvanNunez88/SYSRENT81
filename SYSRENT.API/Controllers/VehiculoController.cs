using MediatR;
using Microsoft.AspNetCore.Mvc;
using SYSRENT.Application.Features.Vehiculo.Command;
using SYSRENT.Application.Features.Vehiculo.Query;
using SYSRENT.Domain.Vehiculo.Entity;

namespace SYSRENT.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiculoController(IMediator _mediator) : ControllerBase
{
    [HttpPost("AgregarVehiculo")]
    public async Task<IActionResult> AgregarVehiculo([FromBody] VEHICULO Vehiculo)
    {
        return Ok(await _mediator.Send(new AddVehiculoCommand(Vehiculo)));
    }

    [HttpPut("ActualizarVehiculo")]
    public async Task<IActionResult> ActualizarVehiculo([FromBody] UPDVEHICULO Vehiculo)
    {
        return Ok(await _mediator.Send(new UpdateVehiculoCommand(Vehiculo)));
    }

    [HttpGet("ListaVehiculos")]
    public async Task<IActionResult> ListaVehiculos()
    {
        return Ok(await _mediator.Send(new GetAllVehiculosQuery()));
    }

}
