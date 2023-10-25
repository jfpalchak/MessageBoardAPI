using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace MessageBoardApi.Models;

public class ApplicationUser : IdentityUser
{
  [JsonIgnore]
  public List<Message> Messages { get; set; } // One to Many

  // [JsonIgnore]
  // public List<GroupUser> JoinEntities { get; }
}