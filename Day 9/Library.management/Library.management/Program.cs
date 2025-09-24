
using Contract.Interfaces.Repo_Interface;
using Contract.Interfaces.Service_Interface;
using Library.management.Data;
using Library.management.Repo;
using Library.management.Repo.Interface;
using Library.management.Service;
using Library.management.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Library.management;

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

        builder.Services.AddScoped<IAuthurService, AuthorService>();
        builder.Services.AddScoped<IBorrowerService, BorrowerService>();
        builder.Services.AddScoped<IBookService, BookService>();

        builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();
        builder.Services.AddScoped<IBorrowerRepo, BorrowerRepo>();
        builder.Services.AddScoped<IBookRepo, BookRepo>();


        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();




        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        // Ensure database is created (what is this)
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
        }

        app.Run();
    }
}
