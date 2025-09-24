using Library.management.Data;
using Library.management.Models.DTO;
using Library.management.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace Library.management.Repo;

public class AdvanceQueryRepo: IAdvanceQueryRepo
{
    ApplicationDbContext _context;
    public AdvanceQueryRepo(ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<List<TopBook>> GetTop3BorrowedAsync()
    {

        return await _context.Books
        .Select(b => new TopBook
        {
            Title = b.Title,
            BorrowCount = b.Book_Borrowers.Count()  // Count how many times this book was borrowed
        })
        .OrderByDescending(b => b.BorrowCount)
        .Take(3)
        .ToListAsync();


    }

    public async Task<List<CountBook>> GetAuthorBookCountAsync()
    {
        return await _context.Authors
            .Select(bc => new CountBook
            {
                AuthorId = bc.AuthorId,
                BookCount = bc.Books.Count()
            }).ToListAsync();
    }

    public async Task<List<BorrowerCount>> GetBorrowerCountAsync()
    {
        return await _context.borrowers

                                .Select(bc => new BorrowerCount
                                {
                                    BorrowerId = bc.Id,
                                    BorrowCount = bc.Book_Borrowers.Count(),

                                    BorrowerName = bc.Name
                                })
                                .OrderByDescending(bc => bc.BorrowCount)

                                .ToListAsync();
    }
}
