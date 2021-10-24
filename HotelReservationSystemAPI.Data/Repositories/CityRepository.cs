using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class CityRepository : Repository<CityEntity>, ICityRepository
    {
        public CityRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }
    }
}
