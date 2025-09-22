using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Library.management.Models;

public class Author
{
    [Key]
    public int AuthorId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Country { get; set; }

    [JsonIgnore]
    public ICollection<Book>? Books { get; set; }
}
