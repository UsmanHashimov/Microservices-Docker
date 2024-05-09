using Employee.Application.Abstractions;
using Employee.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure
{
    public static class EmployeeInfrastructureDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IEmployeeDBContext, EmployeeDBContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("EmployeeConnectionString"));
            });

            return services;
        }
    }
}
