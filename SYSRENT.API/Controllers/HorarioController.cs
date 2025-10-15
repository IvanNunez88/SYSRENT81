using MediatR;
using Microsoft.AspNetCore.Mvc;
using SYSRENT.Application.Features.Horario.Command;
using SYSRENT.Application.Features.Horario.Query;
using SYSRENT.Domain.Horario.Entity;

namespace SYSRENT.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HorarioController(IMediator _mediator) : ControllerBase
{
    [HttpGet("ListaCatHorario")]
    public async Task<IActionResult> ListaCatHorario()
    {
        return Ok(await _mediator.Send(new GetCatHorarioQuery()));
    }

    [HttpPost("AgregarHorario")]
    public async Task<IActionResult> AgregarHorario([FromBody] HORARIO Horario)
    {
        return Ok(await _mediator.Send(new AddHorarioCommand((Horario))));
    }

}
