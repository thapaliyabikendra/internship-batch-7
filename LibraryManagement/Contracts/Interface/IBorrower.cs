using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface
{
    public interface IBorrower
    {
        Task<Borrower> Insert(Borrower author);
        Task<Borrower> getbyId(int id);
        Task<Borrower> Update(int id, Borrower borrower);
        Task<IEnumerable<Borrower>> getAll();
    }
}
