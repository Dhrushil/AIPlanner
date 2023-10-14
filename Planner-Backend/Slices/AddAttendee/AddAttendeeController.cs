using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Planner_Backend.Slices.AddAttendee;

[ApiController]
[Route("api/[controller]")]
public class AddAttendeeController : ControllerBase
{
    [HttpPost]
    public async Task<AddAttendee.Response> Index(
        [FromBody] AddAttendee.Request request,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken) => await mediator.Send(request, cancellationToken);
}