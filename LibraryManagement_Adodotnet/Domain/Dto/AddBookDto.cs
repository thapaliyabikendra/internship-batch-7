using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto;

public class AddBookDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string ISBN { get; set; }
    public required string AuthorId { get; set; }

}
