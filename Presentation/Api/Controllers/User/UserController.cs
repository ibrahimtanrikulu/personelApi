using Application.Abstract.Services.User;
using Application.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("post")]
        public async Task<IActionResult> Post(UserCreateModel model)
        {
            bool result = await _userService.CreateAsync(model);
            return Ok(result);
        }

        [Route("login")]
        public async Task<IActionResult> login(UserLoginModel model)
        {
            UserLoginResultModel result = await _userService.LoginAsync(model);
            return Ok(result);
        }
    }
}
