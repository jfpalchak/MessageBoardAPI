using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoardApi.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using MessageBoardApi.Wrappers;
using MessageBoardApi.Filters;
using MessageBoardApi.Services;
using MessageBoardApi.Helpers;

namespace MessageBoardApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class GroupsController : ControllerBase
{
  private readonly MessageBoardApiContext _db;
  private readonly UserManager<ApplicationUser> _userManager;
  private readonly IUriService _uriService;

  public GroupsController(MessageBoardApiContext db, UserManager<ApplicationUser> userManager, IUriService uriService)
  {
    _db = db;
    _userManager = userManager;
    _uriService = uriService;
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
  // Now, with PAGINATION!
  [HttpGet("{id}/messages")]
  public async Task<IActionResult> GetMessages([FromQuery] PaginationFilter filter, int id)
  {
    // get the route of the current controller action method 
    // It is this string that we are going to pass to our helper class method.
    string route = Request.Path.Value;
    PaginationFilter pageFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

    List<Message> pagedMessages = await _db.Messages
                                                  .Where(m => m.GroupId == id)
                                                  .Skip((pageFilter.PageNumber - 1) * pageFilter.PageSize)
                                                  .Take(pageFilter.PageSize)
                                                  .ToListAsync();

    int totalRecords = await _db.Messages.Where(m => m.GroupId == id).CountAsync();
    // Call the Helper class with required params, create our paginated response.
    PagedResponse<List<Message>> pagedResponse = PaginationHelper.CreatePagedResponse<Message>(pagedMessages, pageFilter, totalRecords, _uriService, route);

    return Ok(pagedResponse);
  }

  // GET: api/groups/{id}/messages/{id}
  [HttpGet("{id}/messages/{messageId}")]
  public async Task<IActionResult> GetMessage(int id, int messageId)
  {
    Message message = await _db.Messages
                                        // .Include(message => message.Group)
                                        // .Include(message => message.User)
                                        .FirstOrDefaultAsync(message => message.MessageId == id && message.GroupId == id);

    return Ok(new Response<Message>(message));
  }

  // POST: api/groups/{id}/messages
  [HttpPost("{id}/messages")]
  [Authorize]
  public async Task<ActionResult<Message>> PostMessage(int id, Message message)
  {
    message.GroupId = id;
    // message.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
    // get the user claim from the Token
    message.UserId = User.Claims.Where(u => u.Type == "userId").FirstOrDefault().Value;
    message.Date = DateTime.Now;
    _db.Messages.Add(message);
    await _db.SaveChangesAsync();
    return CreatedAtAction(nameof(GetMessage), new { id = id, messageId = message.MessageId }, message);
  }
}

