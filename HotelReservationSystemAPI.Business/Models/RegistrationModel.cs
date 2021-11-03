namespace HotelReservationSystemAPI.Business.Models
{
    public class RegistrationModel
    {
        public string Username { get; set; }
        
        public string Password { get; set; }

        public int RoleId { get; } = 2;
    }
}
