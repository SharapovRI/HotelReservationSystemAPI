using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class AdditionalFacilityOrderRepository : Repository<AdditionalFacilityOrderEntity>, IAdditionalFacilityOrderRepository
    {
        public AdditionalFacilityOrderRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {
            
        }
    }
}
