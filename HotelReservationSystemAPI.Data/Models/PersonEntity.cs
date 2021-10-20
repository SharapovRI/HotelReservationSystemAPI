using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class PersonEntity:Entity
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public RoleEntity Role { get; set; }
    }
}
