using Contract.Interfaces.Author;
using Contract.Repository;
using LibraryManagementApplication.Data;
using LibraryManagementApplication.Enums;
using LibraryManagementApplication.Repository;
using LibraryManagementApplication.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Entity Framework Core with SQLite with Lazy loading
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")).UseLazyLoadingProxies()
);

// Register the EF Core implementation with the EfCore key
builder.Services.AddKeyedScoped<IAuthorRepository, AuthorEfRepository>(DataSource.EfCore);

// Register the Dapper implementation with the Dapper key
builder.Services.AddKeyedScoped<IAuthorRepository, AuthorDapperRepository>(DataSource.Dapper);

//Register entity Services
builder.Services.AddScoped<IAuthorService, AuthorService>();

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

app.Run();
