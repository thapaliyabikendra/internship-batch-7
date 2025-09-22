using Library.management.Models;

namespace Library.management.Service.Interface;

public interface IBorrowerService
{
    Task<IEnumerable<Borrower>> GetAllBorrowerAsync();

    Task<Borrower> DeleteBorrowerByIDAsync(int id);
}
