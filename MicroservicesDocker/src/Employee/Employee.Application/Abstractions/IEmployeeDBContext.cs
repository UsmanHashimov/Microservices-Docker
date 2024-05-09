using Employee.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Abstractions
{
    public interface IEmployeeDBContext
    {
        public DbSet<EmployeeModel> Employees { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
