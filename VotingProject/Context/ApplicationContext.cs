using Microsoft.EntityFrameworkCore;
using VotingProject.Models;

namespace VotingProject.Context;

public class ApplicationContext : DbContext, IApplicationContext
{
    public DbSet<UsersModel> users { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
    {

    }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}