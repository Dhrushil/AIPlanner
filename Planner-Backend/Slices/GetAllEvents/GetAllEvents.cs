using MediatR;
using Planner_Backend.Model;
using Planner_Backend.Mongo;

namespace Planner_Backend.Slices.GetAllEvents;

public class GetAllEvents
{
    public record Request(string? UserId) : IRequest<Response>;

    public record Response(IReadOnlyList<EventDocument> Events);

    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMongoRepository<EventDocument> _eventRepository;

        public Handler(IMongoRepository<EventDocument> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var events = (await _eventRepository.FindManyAsync(e => e.Attendees.Contains(request.UserId))).ToList();
            return new Response(events);
        }
    }
}