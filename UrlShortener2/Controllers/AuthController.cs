using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UrlShortener2.Models;
using UrlShortener2.Models.User;
using UrlShortener2.Context;

namespace UrlShortener2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private AuthController userManager;
        private readonly AuthDbContext _auth;

        public AuthController(ILogger<AuthController> logger, AuthDbContext auth)
        {
            _logger = logger;
            _auth = auth;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Get()
        {

            return Ok(_auth.UserInfos.ToList());
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserInfo user)
        {
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }
            if(_auth.UserInfos.ToList().Find(x=> user.UserName == x.UserName && user.Password == x.Password)!=null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new AuthenticatedResponse { Token = tokenString });
            }
            return Unauthorized();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserForRegistration user)
        {
            if (user is null|| !user.IsConfirmPassword())
            {
                return BadRequest("Invalid client request");
            }
            
            if (_auth.UserInfos.ToList().Find(x => user.UserName == x.UserName) == null)
            {
                UserInfo newUser = new UserInfo() { UserName=user.UserName, Password=user.Password };
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                _auth.UserInfos.Add(newUser);
                _auth.UserRoles.Add(new UserRole() { RoleId=2, UserId=newUser.Id});
                _auth.SaveChanges();
                return Ok(new AuthenticatedResponse { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}
