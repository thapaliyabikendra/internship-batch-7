using LibraryManagement_Day10.Contract.Interface.IRepository;
using LibraryManagement_Day10.Contract.Interface.IServices;
using LibraryManagement_Day10.LibraryManagement.Infrastructure.Data;
using LibraryManagement_Day10.LibraryManagement.Infrastructure.Repository;
using LibraryManagement_Day10.LibraryManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ??
"Data Source=librarymanagement.db"));
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IAuthorRepo, AuthorReps>();
builder.Services.AddScoped<IBookRepo, BookReps>();

builder.Services.AddScoped<IBookServices, BookService>();
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ??
//                 "Data Source=internship.db"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Author}/{action=AddAuthor}/{id?}")
    .WithStaticAssets();


app.Run();
