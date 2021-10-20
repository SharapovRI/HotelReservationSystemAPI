using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class PersonModel
    {
        public int id { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public int role_id { get; set; }

        public RoleModel Role { get; set; }
    }
}
