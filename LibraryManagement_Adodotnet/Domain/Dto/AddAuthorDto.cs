using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto;

 public class AddAuthorDto
{
    public required String Id { get; set; }
    public required String Name { get; set; }
    public required String Country { get; set; }
}
