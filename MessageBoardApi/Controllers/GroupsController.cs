using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoardApi.Models;
// using MessageBoardApi.Migrations;

namespace MessageBoardApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class GroupsController : ControllerBase
{
  private readonly MessageBoardApiContext _db;

  public GroupsController(MessageBoardApiContext db)
  {
    _db = db;
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

}