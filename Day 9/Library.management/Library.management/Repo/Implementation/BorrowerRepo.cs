using Library.management.Data;
using Library.management.Models;
using Library.management.Repo.Interface;
using Library.management.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Library.management.Repo.Implementation;

public class BorrowerRepo:IBorrowerRepo
{
    public readonly ApplicationDbContext _context;
    public BorrowerRepo(ApplicationDbContext context)
    {

        _context = context;

    }

    public async Task<IEnumerable<Borrower>> GetAllBorrowerAsync()
    {
        return await _context.borrowers.Where(b => b.IsActive == true).ToListAsync();

    }

    public async Task<Borrower> DeleteBorrowerByIDAsync(int id)
    {
        var data = await _context.borrowers.Where(b => b.IsActive == true && b.Id == id).FirstOrDefaultAsync();

        _context.borrowers.Remove(data);
        _context.SaveChangesAsync();

        return data;


    }
}
