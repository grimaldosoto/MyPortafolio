using Catalog.Application.Dtos.User.Request;
using Catalog.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestDto requestDto)
        {
            return Ok(await _userApplication.CreateUser(requestDto));
        }

        [AllowAnonymous]
        [HttpPost("Generate/Token")]
        public async Task<IActionResult> GenerateToken([FromBody] TokenRequestDto requestDto)
        {
            return Ok(await _userApplication.GenerateToken(requestDto));
        }
    }
}
