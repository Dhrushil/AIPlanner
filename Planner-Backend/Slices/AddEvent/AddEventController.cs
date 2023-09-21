using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Planner_Backend.Slices.AddEvent;

[ApiController]
[Route("api/[controller]")]
public class AddEventController : ControllerBase
{
    [HttpPost]
    public async Task<AddEvent.Response> Index([FromBody] AddEvent.Request request,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken) => await mediator.Send(request, cancellationToken);
}