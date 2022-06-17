using GUWebAPI.DataTransferObjects;
using GUWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GUWebAPI.Controllers
{
    [Route("groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public GroupController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Group>>> GetGroups()
        {
           // return Ok(await _dataContext.Groups.ToListAsync());
           var groups = await _dataContext.Groups
                .Include(group => group.Users)
                .ToListAsync();

            return groups;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(Guid id)
        {
            var groups = await _dataContext.Groups
                        .Where(group => group.Id == id)
                        .Include(group => group.Users)
                        .ToListAsync();

            return Ok(groups);
        }

        [HttpPost]
        public async Task<ActionResult<List<Group>>> AddGroup(CreateGroupDTO groupDTO)
        {
            Group group = new()
            {
                Id = Guid.NewGuid(),
                Name = groupDTO.Name
            };
            await _dataContext.Groups.AddAsync(group);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Groups.ToListAsync());
        }

        /*       [HttpPut("{id}")]
               public async Task<ActionResult<List<Group>>> UpdateGroup(Guid id, UpdateGroupDTO groupDTO)
               {
                   var existingGroup = await _dataContext.Groups.FindAsync(id);
                   if (existingGroup == null)
                   {
                       return NotFound();
                   }

                   existingGroup.Name = groupDTO.Name;
                   await _dataContext.SaveChangesAsync();

                   return Ok(await _dataContext.Groups.ToListAsync());
               } */

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Group>>>AddUserToGroup(Guid id, AddUserToGroupDTO userDTO)
        {
            var existingGroup = await _dataContext.Groups.FindAsync(id);
            if (existingGroup == null)
            {
                return NotFound();
            }

            var addedUser = await _dataContext.Users.FindAsync(userDTO.UserID);
            if (addedUser == null)
            {
                return NotFound();
            }

            addedUser.Groups.Add(existingGroup);
            existingGroup.Users.Add(addedUser);

            _dataContext.SaveChanges();

            return Ok(await _dataContext.Groups.ToListAsync());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Group>>> DeleteGroup(Guid id)
        {
            var group = await _dataContext.Groups.FindAsync(id);

            if (group == null)
                return NotFound();

            _dataContext.Groups.Remove(group);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Groups.ToListAsync());
        }
    }
}
