using EventBusiness.Services;
using EventEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly UserService _userService;
        public UserController(UserService userService) 
        {
            _userService = userService;
        }
        [HttpPost("createUser")]
        public IActionResult CreateUser(UserModel user)
        {
            bool result = _userService.CreateUser(user);
            if (result)
                return Ok("Created");
            else
                return BadRequest();
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetUsers());
        }
        [HttpGet("GetById")]
        public IActionResult Get(int id)
        {
            return Ok(_userService.GetUser(id));
        }
    }
}
