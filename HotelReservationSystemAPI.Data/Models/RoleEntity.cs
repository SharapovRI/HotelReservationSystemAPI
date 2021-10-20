using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class RoleEntity
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

    }
}
