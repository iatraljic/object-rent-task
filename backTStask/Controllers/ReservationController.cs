using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backTStask.Models;
using System.Threading.Tasks;
using System.Linq;


namespace backTStask.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ReservationController : ControllerBase
  {
    private readonly HomeOwnerContext _context;

    public ReservationController(HomeOwnerContext context) => _context = context;

    [HttpGet("/[controller]/join")]
    public IActionResult Get()
    {
        var result = from reservation in _context.ReservationItems
                        join guest in _context.GuestItems on reservation.GuestID equals guest.Id
                        join room in _context.RoomItems on reservation.RoomID equals room.Id
                        join objectRent in _context.ObjectRentItems on room.ObjectRentID equals objectRent.Id
                        select new
                        {
                          fullName = guest.FullName,
                          email = guest.Email,
                          fromDate = reservation.fromDate,
                          toDate = reservation.toDate,
                          roomName = room.RoomName,
                          objectName = objectRent.Name,
                        };
      return Ok(result);
    }

    [HttpPost]
    public ActionResult<Reservation> PostReservationItem(Reservation reservation)
    {
      _context.ReservationItems.Add(reservation);
      _context.SaveChanges();

      return CreatedAtAction("GetReservations", new Reservation{Id = reservation.Id}, reservation);
    }
  }
}