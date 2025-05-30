using Domain.ApiResponse;
using Domain.DTOs.CarDTOs;

namespace Infrastructure.Interfaces;

public interface ICarService
{
    Task<Response<string>> CreateCarAsync(CreateCarDTO createCarDTO);
    Task<Response<string>> DeleteCarAsync(int id);
    Task<Response<List<GetCarDTO>>> GetCarAsync();
    Task<Response<GetCarDTO>> GetCarByIdAsync(int id);
    Task<Response<string>> UpdateCarAsync(int id, UpdateCarDTO updateCarDTO);

    Task<Response<AvailableCarDto>> GetAvailableCarDto(); 


}
