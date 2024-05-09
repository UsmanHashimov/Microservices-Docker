
using Department.API.Interfaces;
using Department.API.Persistence;
using Department.API.Services;
using Microsoft.EntityFrameworkCore;

namespace Department.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<DepartmentDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DepartmentConnectionString"));
            });

            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            
            app.UseSwagger();
            app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
