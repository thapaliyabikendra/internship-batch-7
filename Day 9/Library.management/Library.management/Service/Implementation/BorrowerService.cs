using Library.management.Data;
using Library.management.Models;
using Library.management.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Library.management.Service.Implementation;

public class BorrowerService : IBorrowerService
{
    public readonly ApplicationDbContext _context;
    public BorrowerService(ApplicationDbContext context) 
    {

        _context = context;
    
    }

    public async Task<IEnumerable<Borrower>> GetAllBorrowerAsync()
    {
        return await _context.borrowers.Where(b => b.IsActive == true).ToListAsync();
       
    }

    public async Task<Borrower> DeleteBorrowerByIDAsync(int id)
    {
        var data= await _context.borrowers.Where(b => b.IsActive == true && b.Id==id).FirstOrDefaultAsync();

            _context.borrowers.Remove(data);
            _context.SaveChangesAsync();

            return data;
        

    }
}
