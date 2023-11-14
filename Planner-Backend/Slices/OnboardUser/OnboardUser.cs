using MediatR;
using Planner_Backend.Model;
using Planner_Backend.Mongo;

namespace Planner_Backend.Slices.OnboardUser;

public class OnboardUser
{
    public record Request(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string PhoneNumber) : IRequest<Response>;
    
    public record Response(string Id);
    
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMongoRepository<UserDocument> _userRepository;

        public Handler(IMongoRepository<UserDocument> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var user = new UserDocument(
                email: request.Email,
                firstName: request.FirstName,
                lastName: request.LastName,
                password: request.Password,
                phoneNumber: request.PhoneNumber,
                birthDate: DateTime.Now);
            
            await _userRepository.InsertOneAsync(user);

            return (new Response(user.Id.ToString()));
        }
    }
}