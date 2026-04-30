using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        public AuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto register)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == register.UserName);
            if (user is not null)
            {
                return BadRequest("User Name already taken, try another user name");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(register.Password);

            var newUser = new User
            {
                UserName = register.UserName,
                PasswordHash = hashedPassword,
                Role = register.Role
            };

            _context.Users.Add(newUser);
            _context.SaveChangesAsync();
            return Ok("Registration successful");
        }
    }
}
