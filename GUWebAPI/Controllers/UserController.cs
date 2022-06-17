using GUWebAPI.DataTransferObjects;
using GUWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GUWebAPI.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UserController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _dataContext.Users
            .Include(user => user.Groups)
            .ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var users = await _dataContext.Users
            .Where(user => user.Id == id)
            .Include(user => user.Groups)
            .ToListAsync();

            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Users.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(Guid id, UpdateUserDTO userDTO)
        {
            var existingUser = await _dataContext.Users.FindAsync(id);
            if(existingUser == null)
            {
                return NotFound();
            }

            existingUser.Name = userDTO.Name;
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Users.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(Guid id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            if (user == null)
                return BadRequest("User not found");

            _dataContext.Users.Remove(user);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Users.ToListAsync());
        }

    }
}
