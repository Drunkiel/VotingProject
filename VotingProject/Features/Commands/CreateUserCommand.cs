using MediatR;
using VotingProject.Context;
using VotingProject.Models;

namespace VotingProject.Features.Commands;

public class CreateUserCommand : IRequest<int>
{
    public string firstName { get; }
    public string lastName { get; }
    public string email { get; }
    public string password { get; }


    public class CreateBookCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IApplicationContext _context;

        public CreateBookCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UsersModel
            {
                FirstName = request.firstName,
                LastName = request.lastName,
                Email = request.email,
                Password = request.password
            };
            _context.users.Add(user);

            var result = await _context.SaveChangesAsync();

            return result;
        }
    }
}