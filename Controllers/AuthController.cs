using Microsoft.AspNetCore.Mvc;
using RPG.Dtos.User;
using RPG.Interfaces;
using RPG.Models;

namespace RPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            this._authRepository = authRepository;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto userRegisterDto)
        {
            var response = await _authRepository.Register(
                new User { Username = userRegisterDto.Username }, userRegisterDto.Password);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(UserRegisterDto userRegisterDto)
        {
            var response = await _authRepository.Login(userRegisterDto.Username, userRegisterDto.Password);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

    }
}