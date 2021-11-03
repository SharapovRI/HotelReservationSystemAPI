using System;

namespace HotelReservationSystemAPI.Data.Models
{
    public class RefreshTokenEntity
    {
        public PersonEntity User { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; }
    }
}