using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoardApi.Models;
using Microsoft.AspNetCore.Authorization;
// using MessageBoardApi.Migrations;

namespace MessageBoardApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
  private readonly MessageBoardApiContext _db;

  public MessagesController(MessageBoardApiContext db)
  {
    _db = db;
  }

  // GET: api/messages{?groupId={id}}
  // dateFrom, dateTo: query format must be mm/dd/yyyy
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Message>>> Get(int groupId, string dateFrom, string dateTo)
  {
    IQueryable<Message> query = _db.Messages.AsQueryable();

    if (groupId > 0)
    {
      query = query.Where(entry => entry.GroupId == groupId);
    }

    if (dateFrom != null)
    {
      query = query.Where(entry => entry.Date >= DateTime.Parse(dateFrom));
    }

    if (dateTo != null)
    {
      query = query.Where(entry => entry.Date <= DateTime.Parse(dateTo));
    }

    return await query
                      // .Include(message => message.Group) // we could still "Include" this, and JsonIgnore will still ignore the data
                      .Include(message => message.User)
                      .ToListAsync();
  }

  // GET: api/messages/{id}
  [HttpGet("{id}")]
  public async Task<ActionResult<Message>> GetMessage(int id)
  {
    Message message = await _db.Messages
                                        // .Include(message => message.Group)
                                        .Include(message => message.User)
                                        .FirstOrDefaultAsync(message => message.MessageId == id);

    if (message == null)
    {
      return NotFound();
    }

    return message;
  }

  // POST: api/messages
  [HttpPost]
  public async Task<ActionResult<Message>> Post(Message message)
  {
    _db.Messages.Add(message); // our Messages table only has fields for Id's, the User and Group objects are Model properties that define the relationship in our program, but not in our database
    await _db.SaveChangesAsync();
    return CreatedAtAction(nameof(GetMessage), new { id = message.MessageId }, message);
  }

  // PUT: api/messages/{id}?
  [HttpPut("{id}")] // our route
  public async Task<IActionResult> Put(int id, Message message, string user_name) //api/messages/1?user_name=R
  {


    if (id != message.MessageId || !IsAuthor(id, user_name))
    {
      return BadRequest();
    }

    _db.Messages.Update(message);

    try
    {
      await _db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!MessageExists(id))
      {
        return NotFound();
      }
      else
      {
        throw;
      }
    }
    return NoContent();
  }

  private bool MessageExists(int id)
  {
    return _db.Messages.Any(e => e.MessageId == id);
  }

  private bool IsAuthor(int id, string user_name)
  { // does ANY message exist with BOTH this ID ~AND~ this User?
    return _db.Messages.Any(e => e.MessageId == id && e.User.UserName == user_name);
  }

  // DELETE: api/messages/{id}
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteMessage(int id)
  {
    Message message = await _db.Messages.FindAsync(id);
    if (message == null)
    {
      return NotFound();
    }

    _db.Messages.Remove(message);
    await _db.SaveChangesAsync();

    return NoContent();
  }
}









