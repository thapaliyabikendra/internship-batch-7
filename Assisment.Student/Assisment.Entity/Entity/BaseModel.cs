using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assisment.Entity.Entity;

public class BaseModel
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }=DateTime.Now;
    public DateTime? ModifiedDate {get; set;}
    public bool IsActive { get; set; }

    public int? ModifiedBy { get; set; }
    public int CreatedBy { get; set; }
}
