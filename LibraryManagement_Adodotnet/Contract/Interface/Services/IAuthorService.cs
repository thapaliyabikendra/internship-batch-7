using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Interface.Services
{
    public interface IAuthorService
    {
        void AddAuthor(AddAuthorDto dto);
        List<ReadAllAuthor> GetAllAuthors();

    }
}
