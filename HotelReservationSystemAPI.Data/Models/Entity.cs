using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystemAPI.Data.Models
{
    public class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
