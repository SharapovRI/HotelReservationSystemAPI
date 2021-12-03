using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.QueryModels;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IFacilityCostService
    {
        Task<AdditionalFacilityModel> CreateAsync(FacilityRequestCostModel facilityRequestModel);
        Task UpdateAsync(FacilityPatchRequestCostModel hotelModel);
        Task<IList<AdditionalFacilityModel>> GetListAsync(AdditionalFacilityQueryModel queryModel);
        Task<bool> IsFacilitiesValid(OrderModel orderModel);
        Task<bool> IsCostValid(OrderModel orderModel);
    }
}