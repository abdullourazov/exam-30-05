using System.Data;
using System.Security.Cryptography.X509Certificates;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{

    public DbSet<Car> Car { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
        .HasMany(c => c.Bookings)
        .WithOne(u => u.User)
        .HasForeignKey(f => f.UserId);

        modelBuilder.Entity<Car>()
        .HasMany(c => c.Bookings)
        .WithOne(c => c.Car)
        .HasForeignKey(f => f.CarId);

        
    }

}
