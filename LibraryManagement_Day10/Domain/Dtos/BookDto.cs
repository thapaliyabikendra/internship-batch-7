namespace LibraryManagement_Day10.Domain.Dtos;

public class BookDto
{
    public string? Title { get; set; }
    public string? ISBN { get; set; }
    public Guid AuthorID { get; set; }
    public int PublishedYear { get; set; }
}
