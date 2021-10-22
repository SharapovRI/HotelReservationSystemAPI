using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class RoomModel
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        public HotelModel Hotel { get; set; }

        public int TypeId { get; set; }

        public RoomTypeModel RoomType { get; set; }

        private ICollection<OrderModel> Orders { get; set; }

        public bool IsFree(DateTimeOffset checkInTime, DateTimeOffset checkOutTime)
        {
            var a = Orders.FirstOrDefault(time => time.CheckInTime > checkInTime && time.CheckInTime >= checkOutTime ||
                                                  time.CheckOutTime <= checkInTime && time.CheckOutTime < checkOutTime);

            return a is {};
        }
    }
}
