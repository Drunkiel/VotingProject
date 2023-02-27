using MediatR;
using Microsoft.EntityFrameworkCore;
using VotingProject.Context;

namespace VotingProject.Features.Commands;

public class DeleteUserCommand : IRequest<int>
{
    public string email { get; set; }
    
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IApplicationContext _context;

        public DeleteUserCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.users.Where(a => a.Email == request.email).FirstOrDefaultAsync(cancellationToken: cancellationToken);
                
            if(user == null)
            {
                return default;
            }
            _context.users.Remove(user);

            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}