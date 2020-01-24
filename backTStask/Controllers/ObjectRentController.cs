using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backTStask.Models;

namespace backTStask.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ObjectRentController : ControllerBase
  {
    private readonly HomeOwnerContext _context;

    public ObjectRentController(HomeOwnerContext context) => _context = context;

    [HttpGet]
    public ActionResult<IEnumerable<ObjectRent>> GetObjectsRent()
    {
      return _context.ObjectRentItems;
    }

    [HttpGet("{id}")]
    public ActionResult<ObjectRent> GetObjectRentById(int id)
    {
      var objectRentItem = _context.ObjectRentItems.Find(id);
      if(objectRentItem == null)
      {
        return NotFound();
      }

      return objectRentItem;
    }

    [HttpPost]
    public ActionResult<ObjectRent> PostObjectRentItem(ObjectRent objectRent)
    {
      _context.ObjectRentItems.Add(objectRent);
      _context.SaveChanges();

      return CreatedAtAction("GetObjectsRent", new ObjectRent{Id = objectRent.Id}, objectRent);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateObjectRentItem(int id, ObjectRent objectRent)
    {
      if( id != objectRent.Id)
      {
        return BadRequest();
      }

      _context.Entry(objectRent).State = EntityState.Modified;
      _context.SaveChanges();

      return NoContent();
    }

    //DELETE: guest/id
    [HttpDelete("{id}")]
    public ActionResult<ObjectRent> DeleteObjectRent(int id)
    {
      var objectRentItem = _context.ObjectRentItems.Find(id);
      if(objectRentItem == null)
      {
        return NotFound();
      }

      _context.ObjectRentItems.Remove(objectRentItem);
      _context.SaveChanges();

      return objectRentItem;
    }    
  }
}