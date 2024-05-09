using Microsoft.EntityFrameworkCore;
using Position.API.Models;

namespace Position.API.Persistence
{
    public class PositionDbContext : DbContext
    {
        public PositionDbContext(DbContextOptions<PositionDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<PositionModel> Positions { get; set; }
    }
}
