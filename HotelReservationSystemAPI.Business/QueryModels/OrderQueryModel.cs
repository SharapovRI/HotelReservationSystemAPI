using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.QueryModels
{
    public class OrderQueryModel : QueryModel
    {
        public int UserId { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        //null == все
        //false == прошлые
        //true == будущие
        public bool? WhichTime { get; set; } 
    }
}
