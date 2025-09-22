using Library.management.Data;
using Library.management.Models;
using Library.management.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library.management.Service.Implementation;

public class AuthorService : IAuthurService
{
    ApplicationDbContext _context;
    public AuthorService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Author> AddAuthorAsync( Author author)
    {
        
        _context.AddAsync(author);
        _context.SaveChangesAsync();

        return author;
    }
}
