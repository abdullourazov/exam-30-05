using Domain.ApiResponse;
using Domain.DTOs.CarDTOs;
using Domain.DTOs.UserDTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Controller]
[Route("api/[Controller]")]


public class UserController(IUserService userService)
{
    [HttpGet]
    public async Task<Response<List<GetUserDTO>>> GetUserAsync()
    {
        return await userService.GetUserAsync();
    }

    [HttpPost]
    public async Task<Response<string>> CreateUserAsync(CreateUserDTO createUserDTO)
    {
        return await userService.CreateUserAsync(createUserDTO);
    }

    [HttpGet("id:int")]
    public async Task<Response<GetUserDTO>> GetUserByIdAsync(int id)
    {
        return await userService.GetUserByIdAsync(id);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateUserAsync(int id, UpdateUserDTO updateUserDTO)
    {
        return await userService.UpdateUserAsync(id, updateUserDTO);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteUserAsync(int id)
    {
        return await userService.DeleteUserAsync(id);
    }
}
