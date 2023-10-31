using MediatR;
using Planner_Backend.Model;
using Planner_Backend.Mongo;

namespace Planner_Backend.Slices.AddAttendee;

public class AddAttendee
{
    public record Request(string EventId, string AttendeeId) : IRequest<Response>;
    
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
            var eventDocument = await _eventRepository.FindByIdAsync(request.EventId);
            if (eventDocument == null)
            {
                throw new Exception("Event not found");
            }

            eventDocument.AddAttendee(request.AttendeeId);
            
            await _eventRepository.ReplaceOneAsync(eventDocument);
            
            return new Response(eventDocument.Id.ToString());
        }
    }
}