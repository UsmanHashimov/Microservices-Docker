using Employee.Application.Abstractions;
using Employee.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Persistence
{
    public class EmployeeDBContext : DbContext, IEmployeeDBContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<EmployeeModel> Employees { get; set; }
    }
}
