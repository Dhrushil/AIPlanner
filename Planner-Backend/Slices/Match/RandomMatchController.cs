using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Planner_Backend.Slices.Match;

[ApiController]
[Route("api/[controller]")]
public class RandomMatchController : ControllerBase
{
    [HttpGet]
    public async Task<RandomMatch.Response> Index([FromQuery] RandomMatch.Request request,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken) => await mediator.Send(request, cancellationToken);    
}