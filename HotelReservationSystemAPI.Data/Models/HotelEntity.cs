using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class HotelEntity:Entity
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public List<ServiceCostEntity> ServiceCosts { get; set; }

        public List<RoomEntity> Rooms { get; set; }

        public List<RoomsCostEntity> RoomsCosts { get; set; }
    }
}
