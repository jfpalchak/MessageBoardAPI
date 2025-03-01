using MessageBoardApi.Models;
using MessageBoardApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
// using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// THIS VERSION PREVENTS FEEDBACK LOOPS ("OBJECT CYCLES) BUT LEAVES A REFERENCE TO NULL IN PAYLOAD
// builder.Services.AddControllers().AddJsonOptions(options =>
//         {
//           options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//         });

builder.Services.AddControllers();

builder.Services.AddDbContext<MessageBoardApiContext>(
                  dbContextOptions => dbContextOptions
                    .UseMySql(
                      builder.Configuration["ConnectionStrings:DefaultConnection"],
                      ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                    )
                  )
                );

// Configuring our UriService to get the Base URL
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUriService>(options =>
{
  var accessor = options.GetRequiredService<IHttpContextAccessor>();
  var request = accessor.HttpContext.Request;
  var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
  return new UriService(uri);
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
  .AddEntityFrameworkStores<MessageBoardApiContext>()
  .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => 
{
  options.SaveToken = true;
  options.RequireHttpsMetadata = false;
  options.TokenValidationParameters = new TokenValidationParameters()
  {
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidAudience = builder.Configuration["JWT:ValidAudience"],
    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
  };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
else
{
  app.UseHttpsRedirection();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();