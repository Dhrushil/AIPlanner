using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Planner_Backend.Slices.OnboardUser;

[ApiController]
[Route("api/[controller]")]
public class OnboardUserController : ControllerBase
{
    [HttpPost]
    public async Task<OnboardUser.Response> Index([FromBody] OnboardUser.Request request,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken) => await mediator.Send(request, cancellationToken);
}