using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MessageBoardApi.Models
{
  public class MessageBoardApiContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Message> Messages { get; set; }
    public DbSet<Group> Groups { get; set; }
    // public DbSet<User> Users { get; set; }
    // public DbSet<GroupUser> GroupUsers { get; set; }

    public MessageBoardApiContext(DbContextOptions<MessageBoardApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Group>()
        .HasData(
          new Group { GroupId = 1, Name = "Spider-Man" },
          new Group { GroupId = 2, Name = "Witcher" },
          new Group { GroupId = 3, Name = "Costumes" }
        );

      builder.Entity<Message>()
        .HasData(
          new Message { MessageId = 1, Text = "This new Spider-Man game looks awesome!", GroupId = 1, /* UserId = 2, */ Date = new DateTime(2022, 12, 08, 8, 15, 0) },
          new Message { MessageId = 2, Text = "What did ya'll get for candy? I got rocks.", GroupId = 3, /* UserId = 1, */ Date = new DateTime(2023, 3, 21, 6, 30, 0) },
          new Message { MessageId = 3, Text = "I hate Ciri!", GroupId = 2, /* UserId = 3, */ Date = new DateTime(2020, 5, 13, 8, 11, 0) }
        );

      // builder.Entity<User>()
      //   .HasData(
      //     new User { UserId = 1, Name = "Joey" },
      //     new User { UserId = 2, Name = "Richard" },
      //     new User { UserId = 3, Name = "Onur" }
      //   );

      // builder.Entity<GroupUser>()
      //   .HasData(
      //     new GroupUser { GroupUserId = 1, UserId = 2, GroupId = 1 },
      //     new GroupUser { GroupUserId = 2, UserId = 1, GroupId = 3 },
      //     new GroupUser { GroupUserId = 3, UserId = 3, GroupId = 2 },
      //     new GroupUser { GroupUserId = 4, UserId = 2, GroupId = 2 },
      //     new GroupUser { GroupUserId = 5, UserId = 1, GroupId = 2 }
      //   );
    }

  }
}