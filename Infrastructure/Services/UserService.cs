using System.Net;
using Domain.ApiResponse;
using Domain.DTOs.UserDTOs;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UserService(DataContext context) : IUserService
{
    public async Task<Response<string>> CreateUserAsync(CreateUserDTO createUserDTO)
    {
        var User = new User
        {
            UserName = createUserDTO.UserName,
            Email = createUserDTO.Email,
            Phone = createUserDTO.Phone
        };

        await context.Users.AddAsync(User);
        var result = await context.SaveChangesAsync();

        return result == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "User created successfully");
    }

    public async Task<Response<string>> DeleteUserAsync(int id)
    {
        var User = await context.Users.FindAsync(id);
        if (User == null)
        {
            return new Response<string>("User not found", System.Net.HttpStatusCode.NotFound);
        }

        context.Users.Remove(User);
        var result = await context.SaveChangesAsync();
        return new Response<string>(null, "User deleted successfully");
    }

    public async Task<Response<List<GetUserDTO>>> GetUserAsync()
    {
        var result = await context.Users.ToListAsync();
        var result2 = result.Select(c => new GetUserDTO
        {
            UserName = c.UserName,
            Email = c.Email,
            Phone = c.Phone
        }).ToList();

        return result2 == null
        ? new Response<List<GetUserDTO>>("Something went wrong", HttpStatusCode.NotFound)
        : new Response<List<GetUserDTO>>(result2, "User found succesfully");
    }


    public async Task<Response<GetUserDTO>> GetUserByIdAsync(int id)
    {
        var result = await context.Users.FindAsync(id);
        if (result == null)
        {
            return new Response<GetUserDTO>("User not found", HttpStatusCode.NotFound);
        }

        var result2 = new GetUserDTO
        {
            Id = result.Id,
            UserName = result.UserName,
            Email = result.Email,
            Phone = result.Phone
        };

        return new Response<GetUserDTO>(result2, "User found succesfully");

    }

    public async Task<Response<string>> UpdateUserAsync(int id, UpdateUserDTO updateUserDTO)
    {
        var User = await context.Users.FindAsync(id);
        if (User == null)
        {
            return new Response<string>("User not found", HttpStatusCode.NotFound);
        }

        User.UserName = updateUserDTO.UserName;
        User.Email = updateUserDTO.Email;
        User.Phone = updateUserDTO.Phone;

        var result = await context.SaveChangesAsync();
        return new Response<string>(null, "User updated successfully");

    }
}
