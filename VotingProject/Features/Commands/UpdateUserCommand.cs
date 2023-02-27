using MediatR;
using VotingProject.Context;

namespace VotingProject.Features.Commands;

public class UpdateUserCommand : IRequest<int>
{
    public string firstName { get; }
    public string lastName { get; }
    public string email { get; }
    public string password { get; }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IApplicationContext _context;
        public UpdateBookCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _context.users.FirstOrDefault(a => a.Email == request.email);
            if (user == null)
            {
                return default;
            }
            else
            {
                user.FirstName = request.firstName;
                user.LastName = request.lastName;
                user.Email = request.email;
                user.Password = request.password;

                var result = await _context.SaveChangesAsync();
                return result;
            }
        }
    }
}