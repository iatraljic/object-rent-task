using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backTStask.Models;

namespace backTStask.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class GuestController : ControllerBase
  {
    private readonly HomeOwnerContext _context;

    public GuestController(HomeOwnerContext context) => _context = context;

    [HttpGet]
    public ActionResult<IEnumerable<Guest>> GetGuests()
    {
      return _context.GuestItems;
    }

    [HttpGet("/[controller]/coll")]
    public IEnumerable<Guest> GetGuestsColl()
    {
      return _context.GuestItems
        .Include(a => a.Reservations);
    }
    
    [HttpPost]
    public ActionResult<Guest> PostGuestItem(Guest guest)
    {
      _context.GuestItems.Add(guest);
      _context.SaveChanges();

      return CreatedAtAction("GetGuests", new Guest{Id = guest.Id}, guest);
    }

    //PUT: guest/id
    [HttpPut("{id}")]
    public ActionResult UpdateGuestItem(int id, Guest guest)
    {
      if( id != guest.Id)
      {
        return BadRequest();
      }

      _context.Entry(guest).State = EntityState.Modified;
      _context.SaveChanges();

      return NoContent();
    }

    //DELETE: guest/id
    [HttpDelete("{id}")]
    public ActionResult<Guest> DeleteGuest(int id)
    {
      var guestItem = _context.GuestItems.Find(id);
      if(guestItem == null)
      {
        return NotFound();
      }

      _context.GuestItems.Remove(guestItem);
      _context.SaveChanges();

      return guestItem;
    }
  }
}