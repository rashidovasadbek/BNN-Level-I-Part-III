using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using N70.Identity.Domin.Entities;

namespace N70.Identity.Persistace.DataContext;

public class IdentityDbContext : DbContext
{
    //public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    }
}