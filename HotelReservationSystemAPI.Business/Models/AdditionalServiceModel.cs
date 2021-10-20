using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class AdditionalServiceModel
    {
        public int id { get; set; }

        public string name { get; set; }

        public ICollection<CostsOfServicesModel> CostsOfService { get; set; }
    }
}
