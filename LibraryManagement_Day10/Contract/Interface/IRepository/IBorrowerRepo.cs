using LibraryManagement_Day10.LibraryManagement.Core.Models;

namespace LibraryManagement_Day10.Contract.Interface.IRepository
{
    public interface IBorrowerRepo
    {
        void DeleteBorrowerAsync(int borrowerId);
    }
}
