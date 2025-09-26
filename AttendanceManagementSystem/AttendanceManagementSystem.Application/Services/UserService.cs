using AttendanceManagementSystem.Contracts.Interfaces.User;
using AttendanceManagementSystem.Contracts.Repository;
using AttendanceManagementSystem.Domain.Dtos;
using AttendanceManagementSystem.Domain.Dtos.User;
using AttendanceManagementSystem.Domain.Entities.Application;
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.Application.Services;

/// <summary>
/// Provides bussiness logic for managing users
/// </summary>
public class UserService : IUserService
{
    private readonly IGenericRepository<User> _userRepo;
    private readonly ILogger<UserService> _logger;

    public UserService(IGenericRepository<User> userRepo, ILogger<UserService> logger)
    {
        _userRepo = userRepo;
        _logger = logger;
    }

    /// <summary>
    /// Creates a new user
    /// </summary>
    /// <param name="model"> The user details to create </param>
    /// <returns> newly created users Id</returns>
    public async Task<ServiceResponseDto<Guid>> CreateAsync(UserDto model)
    {
        if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.PhoneNumber))
        {
            _logger.LogWarning("User creation failed. Name or PhoneNumber is empty.");
            return new ServiceResponseDto<Guid>
            {
                IsSuccess = false,
                Message = "Name and Phonenumber cannot be empty"
            };
        }

        try
        {
            var exists = _userRepo.GetQueryable().Any(u => u.PhoneNumber == model.PhoneNumber);

            if (exists)
            {
                _logger.LogWarning("User creation failed. Phonenumber already exists.");

                return new ServiceResponseDto<Guid>
                {
                    IsSuccess = false,
                    Message = "Phone number already exists"
                };
            }

            var user = new User
            {
                Name = model.Name.Trim(),
                PhoneNumber = model.PhoneNumber.Trim(),
                AddedDate = DateTime.UtcNow
            };

            var result = await _userRepo.InsertAsync(user);
            _logger.LogInformation("User created successfully with Id {UserId}", result.Id);
            return new ServiceResponseDto<Guid>
            {
                IsSuccess = true,
                Data = user.Id,
                Message = "User added successfully"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating User: {UserName}", model.Name);

            throw;
        }
    }

    /// <summary>
    /// Deletes a user based on Id
    /// </summary>
    /// <param name="id"> The Id of the user to delete</param>
    /// <returns> success status with message </returns>
    public async Task<ServiceResponseDto<bool>> DeleteAsync(Guid id)
    {
        _logger.LogDebug("Deleting User with Id: {UserId}", id);

        try
        {
            var user = await _userRepo.GetAsync(id);
            if (user == null)
            {
                _logger.LogWarning(" User with Id {UserId} not found for deletion", id);
                return new ServiceResponseDto<bool>
                {
                    IsSuccess = false,
                    Message = "User not found"
                };
            }

            var isDeleted = await _userRepo.DeleteAsync(user);
            if (isDeleted)
            {
                _logger.LogInformation("User with Id {UserId} deleted successfully", id);
                return new ServiceResponseDto<bool>
                {
                    IsSuccess = true,
                    Message = "User deleted",
                    Data = true
                };
            }
            else
            {
                _logger.LogWarning(" User with Id {UserId} not found for deletion", id);
                return new ServiceResponseDto<bool>
                {
                    IsSuccess = false,
                    Message = "User not found",
                    Data = false
                };
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting User with Id {UserId}", id);
            throw;
        }
    }

    /// <summary>
    /// Retrives all users
    /// </summary>
    /// <returns> returns a list of Users</returns>
    public async Task<ServiceResponseDto<IEnumerable<UserDto>>> GetAllAsync()
    {
        _logger.LogDebug("Fetching all users");

        try
        {
            var users = await _userRepo.GetAllAsync();
            var usersDto = users.Select(x => new UserDto
            {
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
            });
            _logger.LogInformation(" Users retrieved successfully");
            return new ServiceResponseDto<IEnumerable<UserDto>>
            {
                Data = usersDto,
                IsSuccess = true
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching all users");
            throw;
        }
    }

    /// <summary>
    /// Retrive a user based on Id
    /// </summary>
    /// <param name="id"> The Id of the user to retrive</param>
    /// <returns>  user detail</returns>

    public async Task<ServiceResponseDto<UserDto>> GetByIdAsync(Guid id)
    {
        _logger.LogDebug("Fetching User by id: {UserId}", id);

        var user = await _userRepo.GetAsync(id);
        if (user == null)
        {
            _logger.LogWarning("User with id {UserId} not found", id);
            return new ServiceResponseDto<UserDto> { IsSuccess = false, Message = "Id not found" };
        }
        var userDto = new UserDto { Name = user.Name, PhoneNumber = user.PhoneNumber, };

        _logger.LogInformation("User with id {UserId} retrieved successfully", id);
        return new ServiceResponseDto<UserDto> { Data = userDto, IsSuccess = true };
    }

    /// <summary>
    /// Updates the existing user entity
    /// </summary>
    /// <param name="id">The id of the user to update</param>
    /// <param name="model">The details of the user to update</param>
    /// <returns></returns>
    public async Task<ServiceResponseDto<bool>> UpdateAsync(Guid id, UserDto model)
    {
        _logger.LogDebug(
            "Updating User Id {UserId} with Name: {Name}, PhoneNumber: {PhoneNumber}",
            id,
            model.Name,
            model.PhoneNumber
        );

        if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.PhoneNumber))
        {
            _logger.LogWarning("User update failed due to missing Name or PhoneNumber");
            return new ServiceResponseDto<bool>
            {
                IsSuccess = false,
                Message = "Name and PhoneNumber cannot be empty"
            };
        }

        try
        {
            var user = await _userRepo.GetAsync(id);
            if (user == null)
            {
                _logger.LogWarning(" User with Id {UserId} not found.", id);
                return new ServiceResponseDto<bool>
                {
                    IsSuccess = false,
                    Message = "User not found"
                };
            }
            user.Name = model.Name;
            user.PhoneNumber = model.PhoneNumber;

            var isUpdated = await _userRepo.UpdateAsync(user);
            if (isUpdated)
            {
                _logger.LogInformation("User with Id {UserId} updated successfully", id);
                return new ServiceResponseDto<bool>
                {
                    IsSuccess = true,
                    Message = "User updated",
                    Data = true
                };
            }
            else
            {
                _logger.LogWarning("User with Id {UserId} not found for update", id);
                return new ServiceResponseDto<bool>
                {
                    IsSuccess = false,
                    Message = "User not found",
                    Data = false
                };
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating User with Id {UserId}", id);
            throw;
        }
    }
}
