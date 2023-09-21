using MediatR;
using Planner_Backend.Model;
using Planner_Backend.Mongo;

namespace Planner_Backend.Slices.AddEvent;

public class AddEvent
{
    public record Request(
        string Title, 
        string? Description, 
        DateTime StartDate, 
        DateTime? EndDate, 
        IReadOnlyList<string>? Attendees,
        IReadOnlyList<string>? Tags) : IRequest<Response>;

    public record Response(string Id);
    
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMongoRepository<EventDocument> _eventRepository;

        public Handler(IMongoRepository<EventDocument> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var eventDocument = new EventDocument(
                title: request.Title,
                description: request.Description,
                startDate: request.StartDate,
                endDate: request.EndDate,
                attendees: request.Attendees,
                tags: request.Tags
                );
            
            await _eventRepository.InsertOneAsync(eventDocument);
            
            return new Response(eventDocument.Id.ToString());
        }
    }
}