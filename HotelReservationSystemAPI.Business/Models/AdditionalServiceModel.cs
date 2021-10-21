using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class AdditionalServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ServiceCostModel> ServiceCosts { get; set; }
    }
}
