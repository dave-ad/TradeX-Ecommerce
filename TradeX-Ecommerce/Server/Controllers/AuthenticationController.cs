﻿namespace TradeXEcommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    //private readonly IUserAccount _userAccount;

    //public AuthenticationController(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signInManager, IUserAccount userAccount)
    //{
    //    _userManager = userManager;
    //    _configuration = configuration;
    //    _signInManager = signInManager;
    //    _userAccount = userAccount;
    //}

    //public AuthenticationController(IUserAccount userAccount)
    //{
    //    _userAccount = userAccount;
    //}

    //[HttpPost("Register")]
    //public async Task<IActionResult> Register([FromBody] RegisterModel model)
    //{



    //    var newUser = new IdentityUser { UserName = model.Email, Email = model.Email };
    //    var result = await _userManager.CreateAsync(newUser, model.Password!);

    //    if (!result.Succeeded)
    //    {
    //        var errors = result.Errors.Select(x => x.Description);
    //        return Ok(new RegisterStatus { Successful = false, Errors = errors });
    //    }

    //    await _userManager.AddToRoleAsync(newUser, "User");
    //    if (newUser.Email!.ToLower().StartsWith("admin"))
    //    {
    //        await _userManager.AddToRoleAsync(newUser, "Admin");
    //        return Ok(new RegisterStatus { Successful = true });

    //    }
    //    return Ok(new RegisterStatus { Successful = true});
    //}

    //[HttpPost("Register")]
    //public async Task<IActionResult> Register(UserDTO userDTO)
    //{
    //    var response = await _userAccount.CreateAccount(userDTO);
    //    return Ok(response);
    //}

    //[HttpPost("Login")]
    //public async Task<IActionResult> Login([FromBody] LoginModel login)
    //{
    //    var result = await _signInManager.PasswordSignInAsync(login.Email!, login.Password!, false, false);
    //    if (!result.Succeeded) return BadRequest(new LoginStatus { Successful = false, Error = "Username or password is incorrect" });

    //    var user = await _signInManager.UserManager.FindByEmailAsync(login.Email!);
    //    var roles = await _signInManager.UserManager.GetRolesAsync(user!);
    //    var claims = new List<Claim>
    //    {
    //        new Claim(ClaimTypes.Name, login.Email!)
    //    };

    //    foreach (var role in roles)
    //    {
    //        claims.Add(new Claim(ClaimTypes.Role, role));
    //    }

    //    //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]!));

    //    var hmac = new HMACSHA256();
    //    var keyBytes = hmac.Key;

    //    //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    //    var creds = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256);
    //    var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

    //    var token = new JwtSecurityToken(
    //        _configuration["JwtIssuer"],
    //        _configuration["JwtAudience"],
    //        claims,
    //        expires: expiry,
    //        signingCredentials: creds
    //    );

    //    return Ok(new LoginStatus { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
    //}
    //}

    //[HttpPost("Login")]
    //public async Task<IActionResult> Login(LoginDTO loginDTO)
    //{
    //    var response = await _userAccount.LoginAccount(loginDTO);
    //    return Ok(response);
    //}
}