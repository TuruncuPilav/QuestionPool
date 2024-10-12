// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Options;
// using Microsoft.IdentityModel.Tokens;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using Core.Data.Entity;
// using Core.Data.Jwt;
// using Core.Repositories.Classes;


// namespace Api.Controllers
// {
//     [Route("[controller]")]
//     [ApiController]
//     //[Authorize(Roles = "Admin")]
//     public class AuthController : ControllerBase
//     {
//         private readonly JwtSettings _jwtSettings;
//         private readonly MemberRepository m;
//         private readonly MemberAuthRepository c;
//         private readonly LoginMember l;

//         public AuthController(IOptions<JwtSettings> jwtSettings)
//         {
//             _jwtSettings = jwtSettings.Value ?? throw new ArgumentNullException(nameof(jwtSettings));
//             m = new MemberRepository();
//             c = new MemberAuthRepository();
//             l = new LoginMember();
//         }

//         [HttpPost("Login")]
//         [AllowAnonymous]
//         public IActionResult Login([FromBody] LoginMember apiUserInformation)
//         {
//             var apiUser = Authentication(apiUserInformation);
//             if (apiUser?.Id == null) return NotFound("User not found!!!!!!!");
//             //if (apiUser == null) return NotFound("User not found");
//             var token = CreateToken(apiUser);

//             return Ok(token);
//         }

//         private string CreateToken(Member apiUser)
//         {
//             if(_jwtSettings == null) throw new Exception("Jwt key is null in settings");

//             var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key!));
//             var creadentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
//             var claimArray = new[]
//             {
//                 new Claim(ClaimTypes.NameIdentifier, apiUser.Name!),
//                 new Claim(ClaimTypes.Role, m.GetRole(apiUser).Role!.ToString())
//             };
            
//             var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claimArray, expires: DateTime.Now.AddHours(1), signingCredentials: creadentials);

//             return new JwtSecurityTokenHandler().WriteToken(token);
//         }

//         private Member Authentication(LoginMember apiUserInformation)
//         {
//             //return m.GetByEmail(apiUserInformation.Email!);
//             return c.Login(apiUserInformation.Email, apiUserInformation.Password);
//         }
//     }

//     public class LoginMember
//     {
//         public string Email { get; set; } = null!;
//         public string Password { get; set; } = null!;
//     }
// }