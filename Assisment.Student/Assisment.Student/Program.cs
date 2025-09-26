
using Assisment.Application.Service;
using Assisment.Contract.Interface.Repo;
using Assisment.Contract.Interface.Service;
using Assisment.Infrastructure.Data;
using Assisment.Infrastructure.Repo;
using Assisment.Student.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Assisment.Student
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IStudentService, StudentService>();

            builder.Services.AddScoped<IStudentRepo, StudentRepo>();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();
            app.UseLogMiddleware();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
