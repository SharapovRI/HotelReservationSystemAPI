using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.Models
{
    public class AuthResponseModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }

        public AuthResponseModel(PersonEntity user, string jwtToken, string refreshToken)
        {
            Id = user.Id;
            Login = user.Login;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}
