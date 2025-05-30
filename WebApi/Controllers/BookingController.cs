using Domain.ApiResponse;
using Domain.DTOs.BookingDTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Controller]
[Route("api/[Controller]")]

public class BookingController(IBookingService bookingService)
{
    [HttpGet]
    public async Task<Response<List<GetBookingDTO>>> GetBookingAsync()
    {
        return await bookingService.GetBookingAsync();
    }

    [HttpPost]
    public async Task<Response<string>> CreateBookingAsync(CreateBookingDTO createBookingDTO)
    {
        return await bookingService.CreateBookingAsync(createBookingDTO);
    }

    [HttpGet("id:int")]
    public async Task<Response<GetBookingDTO>> GetBookingByIdAsync(int id)
    {
        return await bookingService.GetBookingByIdAsync(id);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateBookingAsync(int id, UpdateBookingDTO updateBookingDTO)
    {
        return await bookingService.UpdateBookingAsync(id, updateBookingDTO);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteBookingAsync(int id)
    {
        return await bookingService.DeleteBookingAsync(id);
    }
}
