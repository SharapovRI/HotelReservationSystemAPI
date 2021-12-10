using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Interfaces
{
    public interface IAdditionalFacilityRepository : IRepository<AdditionalFacilityEntity>
    {
        Task<AdditionalFacilityEntity> GetFacility(AdditionalFacilityEntity entity);
    }
}
