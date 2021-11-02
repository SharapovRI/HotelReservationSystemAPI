using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystemAPI.Data.Models
{
    public class RoomsCostEntity : Entity
    {
        public int HotelId { get; set; }
        
        public virtual HotelEntity Hotel { get; set; }

        public int TypeId { get; set; }
        
        public virtual RoomTypeEntity RoomType { get; set; }

        public decimal Cost { get; set; }
    }
}
