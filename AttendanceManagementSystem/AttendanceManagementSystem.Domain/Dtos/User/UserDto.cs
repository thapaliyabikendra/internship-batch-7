using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceManagementSystem.Domain.Entities.Constants;

namespace AttendanceManagementSystem.Domain.Dtos.User;

public record UserDto
{
    [Required]
    [MaxLength(UserConsts.Name.MaxLength)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Length(10, 10)]
    public string PhoneNumber { get; set; } = string.Empty;
}
