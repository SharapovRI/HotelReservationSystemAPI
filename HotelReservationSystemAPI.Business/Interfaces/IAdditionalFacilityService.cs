using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IAdditionalFacilityService
    {
        Task<AdditionalFacilityModel> CreateAsync(FacilityRequestModel additionalFacilityModel);
        Task<AdditionalFacilityModel> GetAsync(int id);
        Task<IEnumerable<AdditionalFacilityModel>> GetListAsync();
        Task Update(AdditionalFacilityModel additionalFacilityModel);
        Task<AdditionalFacilityModel> DeleteAsync(int id);
    }
}