using MediatR;
using Microsoft.AspNetCore.Mvc;
using SYSRENT.Application.Features.Tamaño.Query;
using SYSRENT.Application.Features.Vehiculo.Query;

namespace SYSRENT.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TamanoController(IMediator _mediator) : ControllerBase
{
    [HttpGet("ListaCatTamanos")]
    public async Task<IActionResult> ListaCatTamanos()
    {
        return Ok(await _mediator.Send(new GetCatTamañoQuery()));
    }

}
