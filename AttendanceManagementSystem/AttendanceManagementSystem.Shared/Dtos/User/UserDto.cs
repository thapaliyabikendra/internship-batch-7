using System.ComponentModel.DataAnnotations;
using AttendanceManagementSystem.Shared.Constants;

namespace AttendanceManagementSystem.Shared.Dtos.User;

public record UserDto
{
    [Required]
    [MaxLength(UserConsts.Name.MaxLength)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Length(10, 10)]
    public string PhoneNumber { get; set; } = string.Empty;
}
