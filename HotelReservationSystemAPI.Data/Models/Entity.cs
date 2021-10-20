using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
