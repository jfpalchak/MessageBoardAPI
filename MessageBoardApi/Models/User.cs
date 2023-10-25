using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace MessageBoardApi.Models
{
  public class User
  {
    public int UserId { get; set; }

    public string Name { get; set; }

    [JsonIgnore]
    public List<Message> Messages { get; set; } // One to Many

    [JsonIgnore]
    public List<GroupUser> JoinEntities { get; } // collection navigation property - Many to Many.
  }
}