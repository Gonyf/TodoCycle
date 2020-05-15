using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoCycle.DTO;
using TodoCycle.Interfaces;
using TodoCycle.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TodoCycle.Controllers
{
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthRepository _repo;

        public AuthenticationController(IAuthRepository repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("Logoff")]
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public async Task<bool> Register([FromBody] UserForRegisterDTO userForRegisterDto)
        {
            // validate request
            CustomRegisterValidation(userForRegisterDto);
            if (!ModelState.IsValid)
                return false;   

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            await _repo.Register(userToCreate, userForRegisterDto.Password);

            return true;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDTO userForLoginDto)
        {
                if (!ModelState.IsValid)
            {
                AddErrorsFromModel(ModelState.Values);
                return View();
            }
            userForLoginDto.Username = userForLoginDto.Username.ToLower();

            var userFromRepo = await _repo.Login(userForLoginDto.Username, userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var token = GenerateJWT(userFromRepo);

            return Ok(token);
        }

        private string GenerateJWT(User userFromRepo)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username),
            };  

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.WriteToken(tokenDescriptor);
            return token;
        }

        private void AddErrorsFromModel(ModelStateDictionary.ValueEnumerable values)
        {
            foreach (var error in values.SelectMany(modelState => modelState.Errors))
            {
                ModelState.AddModelError(string.Empty, error.ErrorMessage);
            }
        }

        private async void CustomRegisterValidation(UserForRegisterDTO userForRegisterDto)
        {
            if (string.IsNullOrEmpty(userForRegisterDto.Username))
                return;

            if (await _repo.UserExists(userForRegisterDto.Username.ToLower()))
                ModelState.AddModelError("UserName", "User name is already taken");
        }
    }
}
