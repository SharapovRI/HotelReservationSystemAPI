using HotelReservationSystemAPI.Data.IRepositories;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class AdditionalServiceOrderRepository : Repository<AdditionalServicesOrderEntity>, IAdditionalServiceOrderRepository
    {
        public AdditionalServiceOrderRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {
            
        }
    }
}
