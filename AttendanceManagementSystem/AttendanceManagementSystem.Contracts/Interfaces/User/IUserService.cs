using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceManagementSystem.Domain.Dtos;
using AttendanceManagementSystem.Domain.Dtos.User;

namespace AttendanceManagementSystem.Contracts.Interfaces.User;

public interface IUserService
{
    Task<ServiceResponseDto<Guid>> CreateAsync(UserDto model);

    Task<ServiceResponseDto<bool>> UpdateAsync(Guid id, UserDto model);

    Task<ServiceResponseDto<bool>> DeleteAsync(Guid id);

    Task<ServiceResponseDto<IEnumerable<UserDto>>> GetAllAsync();

    Task<ServiceResponseDto<UserDto>> GetByIdAsync(Guid id);
}
