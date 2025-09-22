using System.ComponentModel.DataAnnotations;

namespace Library.management.Models.DTO;

public class AuthorDTO
{
    
    public int AuthorId { get; set; }
   
    public string Name { get; set; }
    
    public string Country { get; set; }
}
