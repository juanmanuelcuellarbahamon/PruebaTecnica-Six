using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica_Backend.Data;
using PruebaTecnica_Backend.Models;

namespace PruebaTecnica_Backend.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = await _context.Usuarios.ToListAsync();

                if (users == null || users.Count == 0)
                {
                    return NotFound("No users found in the database.");
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving users: {ex.Message}");
            }
        }
    }
}
