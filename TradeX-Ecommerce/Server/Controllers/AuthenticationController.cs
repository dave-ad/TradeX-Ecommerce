using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace TradeXEcommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthenticationController(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _configuration = configuration;
        _signInManager = signInManager;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var newUser = new IdentityUser { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(newUser, model.Password!);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description);
            return Ok(new RegisterStatus { Successful = false, Errors = errors });
        }
        return Ok(new RegisterStatus { Successful = true});
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginModel login)
    {
        var result = await _signInManager.PasswordSignInAsync(login.Email!, login.Password!, false, false);
        if (!result.Succeeded) return BadRequest(new LoginStatus { Successful = false, Error = "Username or password is incorrect" });
        
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, login.Email!)
        };

        //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]!));

        var hmac = new HMACSHA256();
        var keyBytes = hmac.Key;

        //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var creds = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256);
        var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

        var token = new JwtSecurityToken(
            _configuration["JwtIssuer"],
            _configuration["JwtAudience"],
            claims,
            expires: expiry,
            signingCredentials: creds
        );

        return Ok(new LoginStatus { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}
