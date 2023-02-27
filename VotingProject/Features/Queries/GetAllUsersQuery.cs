using MediatR;
using Microsoft.EntityFrameworkCore;
using VotingProject.Context;
using VotingProject.Models;

namespace VotingProject.Features.Queries;

public class GetAllUsersQuery : IRequest<IEnumerable<UsersModel>>
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UsersModel>>
    {
        private readonly IApplicationContext _context;

        public GetAllUsersQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsersModel>> Handle(GetAllUsersQuery request, CancellationToken cancelationToken)
        {
            var userList = await _context.users.ToListAsync(cancellationToken: cancelationToken);

            if (userList == null)
            {
                return null;
            }

            return userList.AsReadOnly();
        }
    }
}