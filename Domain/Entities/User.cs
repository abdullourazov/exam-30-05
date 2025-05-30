using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class User
{
    [Column("UserId")]
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public List<Booking> Bookings { get; set; }
}
