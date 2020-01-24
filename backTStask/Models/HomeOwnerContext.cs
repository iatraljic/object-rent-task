using Microsoft.EntityFrameworkCore;

namespace backTStask.Models
{
  public class HomeOwnerContext : DbContext
  {
    public HomeOwnerContext(DbContextOptions<HomeOwnerContext> options) : base (options)
    {

    }

    public DbSet<Guest> GuestItems {get; set;}
    public DbSet<Room> RoomItems {get; set;}
    public DbSet<Reservation> ReservationItems {get; set;}
    public DbSet<ObjectRent> ObjectRentItems {get; set;}
  }
}