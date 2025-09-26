using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assisment.Entity.Entity;

public class Student:BaseModel
{
    
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Gender { get; set; } = string.Empty;
    [Required]
    public string Email { get; set;} = string.Empty;

    public string? Address { get; set; }
}
