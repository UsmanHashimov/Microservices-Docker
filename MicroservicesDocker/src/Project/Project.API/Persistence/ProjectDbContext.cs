using Microsoft.EntityFrameworkCore;
using Project.API.Models;

namespace Project.API.Persistence
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<ProjectModel> Projects { get; set; }
    }
}
