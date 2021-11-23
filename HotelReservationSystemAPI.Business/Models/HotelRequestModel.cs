﻿using System.Collections.Generic;
using HotelReservationSystemAPI.Business.Models.Request;

namespace HotelReservationSystemAPI.Business.Models
{
    public class HotelRequestModel
    {
        public int? Id { get; set; }
        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public List<PhotoModel> HotelPhotos { get; set; }

        public IEnumerable<RoomCreationRangeModel> Rooms { get; set; }
    }
}
