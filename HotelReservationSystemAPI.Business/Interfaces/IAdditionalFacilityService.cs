using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IAdditionalFacilityService
    {
        Task<AdditionalFacilityModel> CreateAsync(FacilityRequestModel additionalFacilityModel);
        Task<AdditionalFacilityModel> GetAsync(int id);
        Task<IEnumerable<AdditionalFacilityModel>> GetListAsync();
        Task UpdateAsync(FacilityRequestCostModel additionalFacilityModel);
        Task<AdditionalFacilityModel> DeleteAsync(int id);
    }
}