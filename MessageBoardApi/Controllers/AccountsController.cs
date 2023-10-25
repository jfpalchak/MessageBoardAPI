using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MessageBoardApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MessageBoardApi.Controllers;

[ApiController]
[Route("api/[controller]")]
// [Route("[controller]")]
public class AccountsController : ControllerBase
{
  private readonly UserManager<ApplicationUser> _userManager;
  private readonly SignInManager<ApplicationUser> _signInManager;
  private readonly IConfiguration _configuration;

  public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
  {
    _userManager = userManager;
    _signInManager = signInManager;
    _configuration = configuration;
  }

  // POST: api/accounts/register
  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterDto user)
  {
    var userExists = await _userManager.FindByEmailAsync(user.Email);
    if (userExists != null)
    {
      return BadRequest(new { status = "error", message = "Email already exists." });
    }

    var newUser = new ApplicationUser() { Email = user.Email, UserName = user.UserName };
    var result = await _userManager.CreateAsync(newUser, user.Password);

    if (result.Succeeded)
    {
      return Ok(new { status = "success", message = "User has been successfully created."});
    }
    else
    {
      return BadRequest(result.Errors);
    }
  }

  //POST: api/accounts/signin
  [HttpPost("SignIn")]
  public async Task<IActionResult> SignIn(SignInDto userInfo)
  {
    ApplicationUser user = await _userManager.FindByEmailAsync(userInfo.Email);

    if (user != null)
    {
      var signInResult = await _signInManager.PasswordSignInAsync(user, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
      if (signInResult.Succeeded)
      {
        var authClaims = new List<Claim>
        {
          new Claim("userId", user.Id)
          // new Claim(ClaimTypes.Email, user.Email)
        };

        var newToken = CreateToken(authClaims);

        return Ok(new { status = "success", message = $"{userInfo.Email} signed in.", token = newToken });
      }
    }

    return BadRequest(new { status = "error", message = "Unable to sign in." });
  }

  // Generate a user's token
  private string CreateToken(List<Claim> authClaims)
  {
    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

    var token = new JwtSecurityToken(
      issuer: _configuration["JWT:ValidIssuer"],
      audience: _configuration["JWT:ValidAudience"],
      expires: DateTime.Now.AddHours(3),
      claims: authClaims,
      signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
    );

    // take our newly created JwtSecurityToken, and serialize it to be a string
    return new JwtSecurityTokenHandler().WriteToken(token);
  }

  [HttpGet("listclaims")]
  [Authorize]
  public IActionResult ListClaims()
  {
    string header = HttpContext.Request.Headers["Authorization"];
    List<Claim> claims = GetClaims(header);
    return Ok(claims);
  }

  private List<Claim> GetClaims(string authHeader)
  {
    string token = authHeader.Replace("Bearer", "");
    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
    JwtSecurityToken securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

    return (List<Claim>)securityToken.Claims;
  }
}