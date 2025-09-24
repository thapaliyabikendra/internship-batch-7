using Domain.DTO;
using Domain.Entities.Application;
using LibraryManagementApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace Contract.Repository;

public class AuthorEfRepository : IAuthorRepository
{
    private readonly ApplicationDbContext _context;

    public AuthorEfRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddAsync(Author entity)
    {
        await _context.Authors.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null)
        {
            return false;
        }

        _context.Authors.Remove(author);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<GetAuthorDto>> GetAllAsync()
    {
        return await _context
            .Authors.Select(x => new GetAuthorDto { Country = x.Country, Name = x.Name })
            .ToListAsync();
    }

    public async Task<GetAuthorDto?> GetByIdAsync(Guid id)
    {
        return await _context
            .Authors.Where(x => x.Id == id)
            .Select(x => new GetAuthorDto { Country = x.Country, Name = x.Name })
            .FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateAsync(Author entity)
    {
        _context.Authors.Update(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    //public async Task<Guid> CreateAsync(Author entity)
    //{
    //    await _context.Authors.AddAsync(entity);
    //    await _context.SaveChangesAsync();
    //    return entity.Id;
    //}

    //public async Task DeleteAsync(Author entity)
    //{
    //    _context.Authors.Remove(entity);
    //    await _context.SaveChangesAsync();
    //}

    //public async Task<IEnumerable<Author>> GetAllAsync()
    //{
    //    return await _context.Authors.ToListAsync();
    //}

    //public async Task<Author?> GetByPrimaryKey(Guid id)
    //{
    //    return await _context.Authors.FindAsync(id);
    //}

    //public async Task UpdateAsync(Author entity)
    //{
    //    _context.Authors.Update(entity);
    //    await _context.SaveChangesAsync();
    //}
}
