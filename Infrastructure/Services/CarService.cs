using System.Net;
using Domain.ApiResponse;
using Domain.DTOs.CarDTOs;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CarService(DataContext context) : ICarService
{
    public async Task<Response<string>> CreateCarAsync(CreateCarDTO createCarDTO)
    {
        var car = new Car
        {
            Model = createCarDTO.Model,
            PricePerDay = createCarDTO.PricePerDay,
            IsAvailable = createCarDTO.IsAvailable
        };

        await context.Car.AddAsync(car);
        var result = await context.SaveChangesAsync();

        return result == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Car created successfully");
    }

    public async Task<Response<string>> DeleteCarAsync(int id)
    {
        var car = await context.Car.FindAsync(id);
        if (car == null)
        {
            return new Response<string>("car not found", HttpStatusCode.NotFound);
        }

        context.Car.Remove(car);
        var result = await context.SaveChangesAsync();
        return new Response<string>(null, "car deleted successfully");
    }

    public async Task<Response<List<GetCarDTO>>> GetCarAsync()
    {
        var result = await context.Car.ToListAsync();
        var result2 = result.Select(c => new GetCarDTO
        {
            Model = c.Model,
            PricePerDay = c.PricePerDay,
            IsAvailable = c.IsAvailable
        }).ToList();

        return result2 == null
        ? new Response<List<GetCarDTO>>("Something went wrong", HttpStatusCode.NotFound)
        : new Response<List<GetCarDTO>>(result2, "car found succesfully");
    }


    public async Task<Response<GetCarDTO>> GetCarByIdAsync(int id)
    {
        var result = await context.Car.FindAsync(id);
        if (result == null)
        {
            return new Response<GetCarDTO>("car not found", HttpStatusCode.NotFound);
        }

        var result2 = new GetCarDTO
        {
            Id = result.Id,
            Model = result.Model,
            PricePerDay = result.PricePerDay,
            IsAvailable = result.IsAvailable
        };

        return new Response<GetCarDTO>(result2, "car found succesfully");

    }

    public async Task<Response<string>> UpdateCarAsync(int id, UpdateCarDTO updateCarDTO)
    {
        var car = await context.Car.FindAsync(id);
        if (car == null)
        {
            return new Response<string>("Car not found", HttpStatusCode.NotFound);
        }

        car.Model = updateCarDTO.Model;
        car.PricePerDay = updateCarDTO.PricePerDay;
        car.IsAvailable = updateCarDTO.IsAvailable;

        var result = await context.SaveChangesAsync();
        return new Response<string>(null, "car updated successfully");
    }


    public async Task<Response<AvailableCarDto>> GetAvailableCarDto()
    {
        var avv = await context.Car
        .Include(c => c.Bookings)
        .Where(AvailableCarDto)
    }



}
