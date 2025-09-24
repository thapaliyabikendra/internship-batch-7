using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Entities.Application;

namespace Contract.Repository;

public interface IAuthorRepository
{
    Task<GetAuthorDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<GetAuthorDto>> GetAllAsync();
    Task<Guid> AddAsync(Author entity);
    Task<bool> UpdateAsync(Author entity);
    Task<bool> DeleteAsync(Guid id);
}
