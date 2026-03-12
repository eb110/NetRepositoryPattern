using Microsoft.AspNetCore.Mvc;
using PocketBook.Api.Core.IConfiguration;
using PocketBook.Api.Models;

namespace PocketBook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(ILogger<UsersController> logger, IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserPB user)
        {
            if(ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                
                await unitOfWork.Users.CreateAsync(user);
                await unitOfWork.CompleteAsync();

                return CreatedAtAction("GetUserById", new { user.Id }, user);
            }

            return BadRequest("error during user creation");    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserPB>> GetUserById(Guid Id)
        {
            var user = await unitOfWork.Users.GetByIdAsync(Id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }
}
