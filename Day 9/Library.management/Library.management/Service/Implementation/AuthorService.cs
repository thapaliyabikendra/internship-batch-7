using Library.management.Data;
using Library.management.Models;
using Library.management.Repo.Interface;
using Library.management.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library.management.Service.Implementation;

public class AuthorService : IAuthurService
{
    IAuthorRepo _repo;
    public AuthorService(IAuthorRepo repo)
    {
        _repo = repo;
    }
    public async Task<Author> AddAuthorAsync( Author author)
    {
        
        var data=await _repo.AddAuthorAsync(author);

        return data;
    }

    
}
