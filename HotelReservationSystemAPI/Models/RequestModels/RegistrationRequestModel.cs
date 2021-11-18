using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class RegistrationRequestModel//TODO validation
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordRepeat { get; set; }

        public bool IsPasswordsMatch() => Password == PasswordRepeat;
    }
}
