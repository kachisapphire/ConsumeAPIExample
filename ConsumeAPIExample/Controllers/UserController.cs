using ConsumeAPIExample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeAPIExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IReqresService _reqresService;

        public UserController(IReqresService reqresService)
        {
            _reqresService = reqresService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _reqresService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _reqresService.GetUsers();
            return Ok(users);
        }
    }
}
