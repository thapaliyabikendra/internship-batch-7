using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto;

public class UpdateBookDto
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required int PublishedYear { get; set; }
    public required string AuthorId { get; set; }

}
