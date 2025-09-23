using Library.management.Models;

namespace Library.management.Repo.Interface;

public interface IBorrowerRepo
{
    Task<IEnumerable<Borrower>> GetAllBorrowerAsync();

    Task<Borrower> DeleteBorrowerByIDAsync(int id);
}
