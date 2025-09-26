using Contract.ResponceData;
using Library.management.Models;

namespace Library.management.Service.Interface;

public interface IBorrowerService
{
    Task<ResponseData> CreateAsync(Borrower b);

    Task<ResponseData> DeleteAsync(int id);

    Task<ResponseData<Borrower>> GetBorrowerById(int id);

    Task<ResponseData<List<Borrower>>> GetAllBorrower();

    Task<ResponseData> UpdateAsync(Borrower b);
}
