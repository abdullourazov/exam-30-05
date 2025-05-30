using Domain.ApiResponse;
using Domain.DTOs.CarDTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Controller]
[Route("api/[Controller]")]

public class CarController(ICarService carService)
{
    [HttpGet]
    public async Task<Response<List<GetCarDTO>>> GetCarAsync()
    {
        return await carService.GetCarAsync();
    }

    [HttpPost]
    public async Task<Response<string>> CreateCarAsync(CreateCarDTO createCarDTO)
    {
        return await carService.CreateCarAsync(createCarDTO);
    }

    [HttpGet("id:int")]
    public async Task<Response<GetCarDTO>> GetCarByIdAsync(int id)
    {
        return await carService.GetCarByIdAsync(id);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCarAsync(int id, UpdateCarDTO updateCarDTO)
    {
        return await carService.UpdateCarAsync(id, updateCarDTO);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteCarAsync(int id)
    {
        return await carService.DeleteCarAsync(id);
    }



}
