namespace Domain.DTOs.CarDTOs;

public class CreateCarDTO
{
    public int Id { get; set; }
    public string Model { get; set; }
    public decimal PricePerDay { get; set; }
    public bool IsAvailable { get; set; }
}
