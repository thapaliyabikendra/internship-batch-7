using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BookEntity
{
    public string Id { get; set; }
    public string Title { get; set; }
    public int PublishedYear { get; set; }
    public string AuthorId {  get; set; }
    public string ISBN {  get; set; }

}
