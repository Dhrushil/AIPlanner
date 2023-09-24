using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Planner_Backend.Slices.GetAllEvents;

[ApiController]
[Route("api/[controller]")]
public class GetAllEventsController : ControllerBase
{
    [HttpGet]
    public async Task<GetAllEvents.Response> Index(
        [FromQuery] GetAllEvents.Request request,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken) => await mediator.Send(request, cancellationToken);
}