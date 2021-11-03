using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HotelReservationSystemAPI.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;

        public UserService(IConfiguration config, IMapper mapper, IUserRepository userService)
        {
            _config = config;
            _mapper = mapper;
            _userRepository = userService;
        }

        public async Task<AuthResponseModel> AuthenticateAsync(AuthRequestModel model)
        {
            var user = await _userRepository.GetAsync(model.Username, ToSha256(model.Password));

            // return null if user not found
            if (user == null) return null; //TODO Exception

            // authentication successful so generate jwt and refresh tokens
            var jwtToken = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken(user.Id.ToString());

            // save refresh token
            user.RefreshToken = refreshToken;
            await _userRepository.Update(user);

            return new AuthResponseModel(user, jwtToken, refreshToken.Token);
        }

        public async Task<AuthResponseModel> RefreshTokenAsync(string token)
        {
            var user = await _userRepository.GetAsync(token);

            // return null if no user found with token
            if (user == null) return null; //TODO Exception

            var refreshToken = user.RefreshToken;

            // return null if token is no longer active
            if (refreshToken.IsExpired) return null;

            // replace old refresh token with a new one and save
            var newRefreshToken = GenerateRefreshToken(user.Id.ToString());
            user.RefreshToken = newRefreshToken;
            await _userRepository.Update(user);

            // generate new jwt
            var jwtToken = GenerateJwtToken(user);

            return new AuthResponseModel(user, jwtToken, newRefreshToken.Token);
        }

        private string GenerateJwtToken(PersonEntity user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private RefreshTokenEntity GenerateRefreshToken(string id)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshTokenEntity()
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.UtcNow.AddDays(7),
                    Created = DateTime.UtcNow
                };
            }
        }

        private string ToSha256(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            var result = new SHA256Managed().ComputeHash(data);
            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }
    }
}