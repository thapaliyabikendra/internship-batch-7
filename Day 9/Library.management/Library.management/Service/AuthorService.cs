using Contract.ResponceData;
using Library.management.Data;
using Library.management.Models;
using Library.management.Repo.Interface;
using Library.management.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library.management.Service;

public class AuthorService : IAuthurService
{
    IAuthorRepo _repo;
    ResponseData _result;
    public AuthorService(IAuthorRepo repo)
    {
        _repo = repo;
        _result = new ResponseData();
    }
  
    public async Task<ResponseData> CreateAsync(Author author)
    {
       

        if (author == null)
        {
            _result.Message = "Invalid Data";
        }
        else if (string.IsNullOrEmpty(author.Name))
        {
            _result.Message = "Author Name is required";
        }
        else if (string.IsNullOrEmpty(author.Country))
        {
            _result.Message = "Author Country is required";
        }
        else
        {
            author.Name = author.Name.Trim();
            author.Country = author.Country.Trim();

            _result = await _repo.CreateAsync(author);

        }

        return _result;

    }

    public async Task<ResponseData> DeleteAsync(int id)
    {
        if (id == 0)
        {
            _result.Message = "Id is needed for delete";
        }
        else
        {
            _result=await _repo.DeleteAsync(id);
        }
        return _result;
    }

    public async Task<ResponseData<List<Author>>> GetAllAuthor()
    {
        var data = await _repo.GetAllAuthor();
        return data;
    }

    public async Task<ResponseData<Author>> GetAuthorById(int id)
    {
        ResponseData <Author> response=new ResponseData<Author>();
        if (id == 0)
        {
            response.Message = "Id not found";
        }
        else
        {
            response = await _repo.GetAuthorById(id);
        }
        return response;
    }

    public async Task<ResponseData> UpdateAsync(Author author)
    {
        if (author == null)
        {
            _result.Message = "Invalid Data";
        }else if (author.AuthorId==0)
        {
            _result.Message = "Author ID is required for Update";
        }
        else if (string.IsNullOrEmpty(author.Name))
        {
            _result.Message = "Author Name is required";
        }
        else if (string.IsNullOrEmpty(author.Country))
        {
            _result.Message = "Author Country is required";
        }
        else
        {
            
            author.Name = author.Name.Trim();
            author.Country = author.Country.Trim();

            _result = await _repo.UpdateAsync(author);

        }

        return _result;
    }
}
