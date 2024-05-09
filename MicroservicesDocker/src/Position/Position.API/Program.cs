
using Microsoft.EntityFrameworkCore;
using Position.API.Interfaces;
using Position.API.Persistence;
using Position.API.Services;

namespace Position.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<PositionDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("PositionConnectionString"));
            });

            builder.Services.AddScoped<IPositionService, PositionService>();
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
