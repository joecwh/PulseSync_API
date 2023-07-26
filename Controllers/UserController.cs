using API.Resources;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetFruitveges")]
        public async Task<IActionResult> GetFruitVeges()
        {
            try
            {
                var result = _userService.GetFruitVeges();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpGet("GetEmployees")]
        public async Task<IActionResult> GetExpectedOutput()
        {
            try
            {
                var result = await _userService.GetExpectedOutput();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }
    }
}
