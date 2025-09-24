using LibraryManagement_Day10.Contract.Interface.IRepository;
using LibraryManagement_Day10.LibraryManagement.Core.Models;
using LibraryManagement_Day10.LibraryManagement.Infrastructure.Data;
using System.Threading.Tasks;

namespace LibraryManagement_Day10.LibraryManagement.Infrastructure.Repository;

public class BorrowerReps:IBorrowerRepo
{
    ApplicationDbContext _context;
    public BorrowerReps( ApplicationDbContext context )
    {
        _context = context;
    }
    public async void DeleteBorrowerAsync(int id)
    {
        
        var borrower=await _context.Borrowers.FindAsync(id);
        if (borrower == null)
        {
            throw new Exception("No value from id");
        }
        _context.Borrowers.Remove(borrower);
        await _context.SaveChangesAsync();

    }
}
