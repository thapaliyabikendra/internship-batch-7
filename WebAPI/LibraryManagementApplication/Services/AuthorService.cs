using Contract.Interfaces.Author;
using Contract.Repository;
using Domain.DTO;
using LibraryManagementApplication.Enums;

namespace LibraryManagementApplication.Services;

public class AuthorService : IAuthorService
{
    private protected IAuthorRepository _authorDapperRepo;
    private protected IAuthorRepository _authorEfRepo;

    public AuthorService(
        [FromKeyedServices(DataSource.Dapper)] IAuthorRepository authorDapperRepo,
        [FromKeyedServices(DataSource.EfCore)] IAuthorRepository authorEfRepo
    )
    {
        _authorDapperRepo = authorDapperRepo;
        _authorEfRepo = authorEfRepo;
    }

    public async Task<ServiceResponseDto<Guid>> CreateAsync(CreateAuthorDto author)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponseDto<object>> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponseDto<IEnumerable<GetAuthorDto>>> GetAllAsync()
    {
        var authors = await _authorDapperRepo.GetAllAsync();
        return new ServiceResponseDto<IEnumerable<GetAuthorDto>>
        {
            Data = authors,
            IsSuccess = true,
        };
    }

    public async Task<ServiceResponseDto<GetAuthorDto>> GetByIdAsync(Guid id)
    {
        var author = await _authorDapperRepo.GetByIdAsync(id);
        if (author == null)
        {
            return new ServiceResponseDto<GetAuthorDto>
            {
                IsSuccess = false,
                Message = "Id not found"
            };
        }
        return new ServiceResponseDto<GetAuthorDto> { Data = author, IsSuccess = true, };
    }

    public Task<ServiceResponseDto<object>> UpdateAsync(Guid id, UpdateAuthorDto author)
    {
        throw new NotImplementedException();
    }
}
