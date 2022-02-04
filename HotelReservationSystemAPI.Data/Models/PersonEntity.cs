using System.Collections.Generic;

namespace HotelReservationSystemAPI.Data.Models
{
    public class PersonEntity : Entity
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }
        
        public virtual RoleEntity Role { get; set; }

        public virtual List<OrderGroupEntity> OrderGroups { get; set; }
        
        public RefreshTokenEntity RefreshToken { get; set; }
    }
}
