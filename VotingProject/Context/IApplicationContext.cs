using Microsoft.EntityFrameworkCore;
using VotingProject.Models;

namespace VotingProject.Context;

public interface IApplicationContext
{
    DbSet<UsersModel> users { get;set; }

    Task<int> SaveChangesAsync();
}