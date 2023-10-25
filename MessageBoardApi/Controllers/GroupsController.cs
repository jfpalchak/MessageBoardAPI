using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoardApi.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
// using MessageBoardApi.Migrations;

namespace MessageBoardApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class GroupsController : ControllerBase
{
  private readonly MessageBoardApiContext _db;
  private readonly UserManager<ApplicationUser> _userManager;

  public GroupsController(MessageBoardApiContext db, UserManager<ApplicationUser> userManager)
  {
    _db = db;
    _userManager = userManager;
  }

  // GET: api/groups
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Group>>> Get()
  {
    IQueryable<Group> query = _db.Groups.AsQueryable();
    return await query
                      .Include(group => group.Messages)
                      .ThenInclude(m => m.User)
                      .ToListAsync();
  }

  // GET: api/groups/{id}
  [HttpGet("{id}")]
  public async Task<ActionResult<Group>> GetGroup(int id)
  {
    Group thisGroup = await _db.Groups
                                    .Include(group => group.Messages)
                                    .ThenInclude(m => m.User)
                                    .FirstOrDefaultAsync(group => group.GroupId == id);
    if (thisGroup == null)
    {
      return NotFound();
    }

    return thisGroup;
  }

  // GET: api/groups/{id}/messages
  [HttpGet("{id}/messages")]
  public async Task<ActionResult<IEnumerable<Message>>> GetMessages(int id)
  {
    IQueryable<Message> query = _db.Messages.Where(m => m.GroupId == id).AsQueryable();

    return await query.ToListAsync();
  }

  // GET: api/groups/{id}/messages/{id}
  [HttpGet("{id}/messages/{messageId}")]
  public async Task<ActionResult<IEnumerable<Message>>> GetMessage(int id, int messageId)
  {
    IQueryable<Message> query = _db.Messages
                                            .Where(m => m.GroupId == id)
                                            .Where(m => m.MessageId == messageId)
                                            .AsQueryable();

    return await query.ToListAsync();
  }


  // POST: api/groups/{id}/messages
  [HttpPost("{id}/messages")]
  [Authorize]
  public async Task<ActionResult<Message>> PostMessage(int id, Message message)
  {
    message.GroupId = id;
    // message.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
    message.UserId = User.Claims.Where(u => u.Type == "userId").FirstOrDefault().Value;
    message.Date = DateTime.Now;
    _db.Messages.Add(message);
    await _db.SaveChangesAsync();
    return CreatedAtAction(nameof(GetMessage), new { id = id, messageId = message.MessageId }, message);
  }
}

