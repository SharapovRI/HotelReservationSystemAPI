using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models.Response
{
    public class RoomGroupModel
    {
        public int Id { get; set; }

        public string HotelName { get; set; }

        public string Type { get; set; }

        public int SeatsCount { get; set; }

        public decimal Cost { get; set; }

        public List<RoomPhotoModel> RoomPhotos { get; set; }

        public List<int> FreeRoomsId { get; set; }
    }
}
