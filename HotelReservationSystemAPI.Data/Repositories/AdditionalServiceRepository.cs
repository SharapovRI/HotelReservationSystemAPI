using HotelReservationSystemAPI.Data.IRepositories;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class AdditionalServiceRepository : Repository<AdditionalServiceEntity>, IAdditionalServiceRepository
    {
        public AdditionalServiceRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }
    }
}
