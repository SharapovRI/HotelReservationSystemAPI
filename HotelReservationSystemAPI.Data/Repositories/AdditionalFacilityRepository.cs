using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class AdditionalFacilityRepository : Repository<AdditionalFacilityEntity>, IAdditionalFacilityRepository
    {
        public AdditionalFacilityRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }
    }
}
