using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystemAPI.Data.Models
{
    public class PersonEntity : Entity
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual RoleEntity Role { get; set; }
    }
}
