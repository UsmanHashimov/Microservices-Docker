using Department.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Department.API.Persistence
{
    public class DepartmentDbContext : DbContext
    {
        public DepartmentDbContext(DbContextOptions<DepartmentDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<DepartmentModel> Departments { get; set; }
    }
}
