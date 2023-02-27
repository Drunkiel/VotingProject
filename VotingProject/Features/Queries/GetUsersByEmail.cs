using MediatR;
using Microsoft.EntityFrameworkCore;
using VotingProject.Context;
using VotingProject.Models;

namespace VotingProject.Features.Queries;

public class GetUsersByEmailQuery : IRequest<UsersModel>
{
    public string email { get; set; }

    public class GetBookByIdQueryHandler : IRequestHandler<GetUsersByEmailQuery, UsersModel>
    {
        private readonly IApplicationContext _context;

        public GetBookByIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public Task<UsersModel> Handle(GetUsersByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = _context.users.Where(a => a.Email == request.email).FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            return user;
        }
    }
}