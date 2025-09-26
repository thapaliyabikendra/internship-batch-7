using AttendanceManagementSystem.API.Configurations;
using AttendanceManagementSystem.Application.Services;
using AttendanceManagementSystem.Contracts.Interfaces.User;
using AttendanceManagementSystem.Contracts.Repository;
using AttendanceManagementSystem.Infrastructure.Data;
using AttendanceManagementSystem.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Entity Framework Core with SQLite with Lazy loading
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");

    options
        .UseSqlite(
            connectionString,
            b => b.MigrationsAssembly("AttendanceManagementSystem.Infrastructure")
        )
        .UseLazyLoadingProxies();
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericEfRepository<>));

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseRouting();

app.UseMiddleware<RequestResponseLoggingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
