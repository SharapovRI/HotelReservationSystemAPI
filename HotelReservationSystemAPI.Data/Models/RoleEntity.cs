using System.Collections.Generic;

namespace HotelReservationSystemAPI.Data.Models
{
    public class RoleEntity : Entity
    {
        public string Name { get; set; }

        public virtual List<PersonEntity> Persons { get; set; }
    }
}
