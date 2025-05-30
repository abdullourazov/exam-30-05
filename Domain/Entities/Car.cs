using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Car
{
    [Column("CarId")]
    public int Id { get; set; }
    public string Model { get; set; }
    public decimal PricePerDay { get; set; }
    public bool IsAvailable { get; set; }
    
    public List<Booking> Bookings { get; set; }
}
