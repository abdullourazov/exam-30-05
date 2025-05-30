using Domain.ApiResponse;
using Domain.DTOs.UserDTOs;

namespace Infrastructure.Interfaces;

public interface IUserService
{
    Task<Response<string>> CreateUserAsync(CreateUserDTO createUserDTO);
    Task<Response<string>> DeleteUserAsync(int id);
    Task<Response<List<GetUserDTO>>> GetUserAsync();
    Task<Response<GetUserDTO>> GetUserByIdAsync(int id);
    Task<Response<string>> UpdateUserAsync(int id, UpdateUserDTO updateUserDTO );
}
