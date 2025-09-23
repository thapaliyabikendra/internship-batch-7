using Library.management.Models.DTO;

namespace Library.management.Repo.Interface;

public interface IAdvanceQueryRepo
{
    public Task<List<TopBook>> GetTop3BorrowedAsync();
    public Task<List<CountBook>> GetAuthorBookCountAsync();

    public Task<List<BorrowerCount>> GetBorrowerCountAsync();
}
