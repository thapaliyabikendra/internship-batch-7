using Library.management.Models;
using Library.management.Models.DTO;

namespace Library.management.Service.Interface;

public interface IAdvanceQueryService
{
    public Task<List<TopBook>> GetTop3BorrowedAsync();
    public Task<List<CountBook>> GetAuthorBookCountAsync();

    public Task<List<BorrowerCount>> GetBorrowerCountAsync();
}
