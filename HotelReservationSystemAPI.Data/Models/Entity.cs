using System.ComponentModel.DataAnnotations;
using HotelReservationSystemAPI.Data.Interfaces;

namespace HotelReservationSystemAPI.Data.Models
{
    public class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
