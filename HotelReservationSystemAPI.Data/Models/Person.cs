using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class Person
    {
        [Key]
        public int id { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public int role_id { get; set; }

        [ForeignKey("role_id")]
        public Role Role { get; set; }
    }
}
