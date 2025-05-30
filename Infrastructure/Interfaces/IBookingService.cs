using Domain.ApiResponse;
using Domain.DTOs.BookingDTOs;

namespace Infrastructure.Interfaces;

public interface IBookingService
{
    Task<Response<string>> CreateBookingAsync(CreateBookingDTO createBookingDTO);
    Task<Response<string>> DeleteBookingAsync(int id);
    Task<Response<List<GetBookingDTO>>> GetBookingAsync();
    Task<Response<GetBookingDTO>> GetBookingByIdAsync(int id);
    Task<Response<string>> UpdateBookingAsync(int id, UpdateBookingDTO updateBookingDTO);
}
