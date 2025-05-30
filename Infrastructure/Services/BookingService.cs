using System.Net;
using Domain.ApiResponse;
using Domain.DTOs.BookingDTOs;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class BookingService(DataContext context) : IBookingService
{
    public async Task<Response<string>> CreateBookingAsync(CreateBookingDTO createBookingDTO)
    {
        var Booking = new Booking
        {
            UserId = createBookingDTO.UserId,
            CarId = createBookingDTO.CarId,
            StartDate = createBookingDTO.StartDate,
            EndDate = createBookingDTO.EndDate,
            TotalPrice = createBookingDTO.TotalPrice
        };

        await context.Bookings.AddAsync(Booking);
        var result = await context.SaveChangesAsync();

        return result == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Booking created successfully");
    }

    public async Task<Response<string>> DeleteBookingAsync(int id)
    {
        var Booking = await context.Bookings.FindAsync(id);
        if (Booking == null)
        {
            return new Response<string>("Booking not found", HttpStatusCode.NotFound);
        }

        context.Bookings.Remove(Booking);
        var result = await context.SaveChangesAsync();
        return new Response<string>(null, "Booking deleted successfully");
    }


    public async Task<Response<List<GetBookingDTO>>> GetBookingAsync()
    {
        var result = await context.Bookings.ToListAsync();
        var result2 = result.Select(c => new GetBookingDTO
        {
            UserId = c.UserId,
            CarId = c.CarId,
            StartDate = c.StartDate,
            EndDate = c.EndDate,
            TotalPrice = c.TotalPrice
        }).ToList();

        return result2 == null
        ? new Response<List<GetBookingDTO>>("Something went wrong", HttpStatusCode.NotFound)
        : new Response<List<GetBookingDTO>>(result2, "Booking found succesfully");
    }


    public async Task<Response<GetBookingDTO>> GetBookingByIdAsync(int id)
    {
        var result = await context.Bookings.FindAsync(id);
        if (result == null)
        {
            return new Response<GetBookingDTO>("Booking not found", HttpStatusCode.NotFound);
        }

        var result2 = new GetBookingDTO
        {
            Id = result.Id,
            UserId = result.UserId,
            CarId = result.CarId,
            StartDate = result.StartDate,
            EndDate = result.EndDate,
            TotalPrice = result.TotalPrice
        };

        return new Response<GetBookingDTO>(result2, "Booking found succesfully");

    }

    public async Task<Response<string>> UpdateBookingAsync(int id, UpdateBookingDTO updateBookingDTO)
    {
        var Booking = await context.Bookings.FindAsync(id);
        if (Booking == null)
        {
            return new Response<string>("Booking not found", HttpStatusCode.NotFound);
        }

        Booking.UserId = updateBookingDTO.UserId;
        Booking.CarId = updateBookingDTO.CarId;
        Booking.StartDate = updateBookingDTO.StartDate;
        Booking.EndDate = updateBookingDTO.EndDate;
        Booking.TotalPrice = updateBookingDTO.TotalPrice;


        var result = await context.SaveChangesAsync();
        return new Response<string>(null, "Booking updated successfully");

    }
}
