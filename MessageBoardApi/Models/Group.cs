using System.Text.Json.Serialization;

namespace MessageBoardApi.Models
{
  public class Group
  {
    public int GroupId { get; set; }
    public string Name { get; set; }

    // [JsonIgnore]
    public List<Message> Messages { get; set; } // One to Many

    // [JsonIgnore]
    // public List<GroupUser> JoinEntities { get; } // collection navigation property - Many to Many.
  }
}