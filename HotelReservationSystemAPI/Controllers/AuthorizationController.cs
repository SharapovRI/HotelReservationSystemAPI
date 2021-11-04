using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Models.RequestModels;
using Microsoft.AspNetCore.Authorization;

namespace HotelReservationSystemAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthorizationController(IMapper mapper, IUserService userService)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequestModel model)
        {
            var authModel = _mapper.Map<AuthenticateRequestModel, AuthRequestModel>(model);
            var response = await _userService.AuthenticateAsync(authModel);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshRequestModel refreshRequestModel)
        {
            var refreshToken = refreshRequestModel.RefreshToken;
            var response = await _userService.RefreshTokenAsync(refreshToken);

            if (response == null)
                return Unauthorized(new { message = "Invalid token" });
            
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("registrate")]
        public async Task<IActionResult> Registration([FromBody] RegistrationRequestModel registrationRequestModel)
        {
            if (!registrationRequestModel.IsPasswordsMatch())
                return ValidationProblem("Passwords doesn't match");

            var model = _mapper.Map<RegistrationRequestModel, RegistrationModel>(registrationRequestModel);

            var response = await _userService.RegistrateAsync(model);
            return response == null ? ValidationProblem("This login already exists") : Ok(response);
        }
    }
}
