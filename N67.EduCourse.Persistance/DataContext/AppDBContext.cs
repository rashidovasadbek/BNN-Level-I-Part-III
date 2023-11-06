using Microsoft.EntityFrameworkCore;
using N67.EduCourse.Domin.Entities;

namespace Persistance.DataContext;

public class AppDBContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Course> Courses { get; set; }
    
    public DbSet<CourseStudent> StudentCourse { get; set; }

    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {  
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
    }
}