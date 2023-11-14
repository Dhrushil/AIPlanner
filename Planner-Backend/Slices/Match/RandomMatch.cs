using MediatR;
using Planner_Backend.Model;
using Planner_Backend.Mongo;

namespace Planner_Backend.Slices.Match;

public class RandomMatch
{
    public record Request : IRequest<Response>;
    
    public record Response(UserDocument User);
    
    public class RequestHandler : IRequestHandler<Request, Response>
    {
        private readonly IMongoRepository<UserDocument> _userRepository;

        public RequestHandler(IMongoRepository<UserDocument> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            // TODO: Introduce check for online users only
            var users = (await _userRepository.FindManyAsync(_ => true)).ToList();
            
            if (users.Count == 0) throw new Exception("No online users found");
            
            var random = new Random();
            var randomUser = users[random.Next(users.Count)];
            
            return new Response(randomUser);
        }
    }
}