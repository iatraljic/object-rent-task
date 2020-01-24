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
  public class RoomController : ControllerBase
  {
    private readonly HomeOwnerContext _context;

    public RoomController(HomeOwnerContext context) => _context = context;

    [HttpGet]
    public ActionResult<IEnumerable<Room>> GetRooms()
    {
      return _context.RoomItems;
    }

    [HttpGet("{id}")]
    public ActionResult<Room> GetRoomById(int id)
    {
      var roomItem = _context.RoomItems.Find(id);
      if(roomItem == null)
      {
        return NotFound();
      }

      return roomItem;
    }

    [HttpGet("/[controller]/roomObjectName")]
    public IActionResult Get()
    {
        var result = from room in _context.RoomItems
                        join objectRent in _context.ObjectRentItems on room.ObjectRentID equals objectRent.Id
                        select new
                        {
                          id = room.Id,
                          roomName = room.RoomName,
                          objectName = objectRent.Name,
                        };
      return Ok(result);
    }    

    [HttpPost]
    public ActionResult<Room> PostRoomItem(Room room)
    {
      _context.RoomItems.Add(room);
      _context.SaveChanges();

      return CreatedAtAction("GetRooms", new Room{Id = room.Id}, room);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateRoomItem(int id, Room room)
    {
      if( id != room.Id)
      {
        return BadRequest();
      }

      _context.Entry(room).State = EntityState.Modified;
      _context.SaveChanges();

      return NoContent();
    }

    //DELETE: guest/id
    [HttpDelete("{id}")]
    public ActionResult<Room> DeleteRoom(int id)
    {
      var roomItem = _context.RoomItems.Find(id);
      if(roomItem == null)
      {
        return NotFound();
      }

      _context.RoomItems.Remove(roomItem);
      _context.SaveChanges();

      return roomItem;
    }
  }
}