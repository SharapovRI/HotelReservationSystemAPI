using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.QueryModels;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IAdditionalFacilityService
    {
        Task<AdditionalFacilityModel> CreateAsync(FacilityRequestModel additionalFacilityModel);
        Task<AdditionalFacilityModel> GetAsync(int id);
        Task<IList<AdditionalFacilityModel>> GetListAsync(AdditionalFacilityQueryModel queryModel);
        //Task UpdateAsync(FacilityRequestCostModel additionalFacilityModel);
        Task<AdditionalFacilityModel> DeleteAsync(int id);

        Task<bool> IsFacilitiesValid(OrderModel orderModel);
        Task<bool> IsCostValid(OrderModel orderModel);
    }
}