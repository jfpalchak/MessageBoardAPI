using Microsoft.AspNetCore.Identity;
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
      var hasher = new PasswordHasher<IdentityUser>();
      
      builder.Entity<Group>()
        .HasData(
          new Group { GroupId = 1, Name = "Spider-Man" },
          new Group { GroupId = 2, Name = "Witcher" },
          new Group { GroupId = 3, Name = "Costumes" }
        );

      builder.Entity<Message>()
        .HasData(
          new Message { MessageId = 1, Text = "This new Spider-Man game looks awesome!", GroupId = 1, UserId = "def", Date = new DateTime(2022, 12, 08, 8, 15, 0) },
          new Message { MessageId = 2, Text = "What did ya'll get for candy? I got rocks.", GroupId = 3, UserId = "abc", Date = new DateTime(2023, 3, 21, 6, 30, 0) },
          new Message { MessageId = 3, Text = "I hate Ciri!", GroupId = 2, UserId = "ghi", Date = new DateTime(2020, 5, 13, 8, 11, 0) }
        );

      builder.Entity<ApplicationUser>()
        .HasData(
          new ApplicationUser { Id = "abc", UserName = "Joey", NormalizedUserName = "JOEY", Email = "joey@email.com", NormalizedEmail = "JOEY@EMAIL.COM", PasswordHash = hasher.HashPassword(null, "password") },
          new ApplicationUser { Id = "def", UserName = "Richard", NormalizedUserName = "RICHARD", Email = "richard@email.com", NormalizedEmail = "RICHARD@EMAIL.COM", PasswordHash = hasher.HashPassword(null, "password") },
          new ApplicationUser { Id = "ghi", UserName = "Onur", NormalizedUserName = "ONUR", Email = "onur@email.com", NormalizedEmail = "ONUR@EMAIL.COM", PasswordHash = hasher.HashPassword(null, "password") }
        );

      // builder.Entity<GroupUser>()
      //   .HasData(
      //     new GroupUser { GroupUserId = 1, UserId = "def", GroupId = 1 },
      //     new GroupUser { GroupUserId = 2, UserId = "abc", GroupId = 3 },
      //     new GroupUser { GroupUserId = 3, UserId = "ghi", GroupId = 2 },
      //     new GroupUser { GroupUserId = 4, UserId = "def", GroupId = 2 },
      //     new GroupUser { GroupUserId = 5, UserId = "abc", GroupId = 2 }
      //   );

      base.OnModelCreating(builder);
    }

  }
}