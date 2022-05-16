using Basket_Store_MS.Models.DTO;
using Basket_Store_MS.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Basket_Store_MS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) 
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterUser data)
        {
            try
            {
                var user = await _userService.Register(data, this.ModelState);
                if (ModelState.IsValid)
                {
                    return user;
                }
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginData loginData)
        {
            try
            {
                var user = await _userService.Authenticate(loginData.Username, loginData.Password);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return BadRequest("User not found");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
