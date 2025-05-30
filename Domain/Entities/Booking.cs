using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Booking
{
    [Column("BookingId")]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CarId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }

    public Car Car { get; set; }
    public User User { get; set; }

}
