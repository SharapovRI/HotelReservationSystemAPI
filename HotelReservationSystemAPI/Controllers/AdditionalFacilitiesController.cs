using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Models.RequestModels;
using HotelReservationSystemAPI.Models.ResponseModels;
using HotelReservationSystemAPI.Constants;
using Microsoft.AspNetCore.Authorization;

namespace HotelReservationSystemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdditionalFacilitiesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAdditionalFacilityService _additionalFacilityService;

        public AdditionalFacilitiesController(IMapper mapper, IAdditionalFacilityService additionalFacilityService)
        {
            _additionalFacilityService = additionalFacilityService;
            _mapper = mapper;
        }

        [HttpPost("/Facility/Create")]
        [Authorize(Policy = APIPolicies.AdminPolicy)]
        public async Task<IActionResult> CreateFacility([FromBody] FacilityPostModel facilityRequestViewModel)
        {
            var facilityRequestModel = _mapper.Map<FacilityPostModel, FacilityRequestModel>(facilityRequestViewModel);

            var createdEntity = await _additionalFacilityService.CreateAsync(facilityRequestModel);

            var facility = _mapper.Map<AdditionalFacilityModel, AdditionalFacilityViewModel>(createdEntity);

            return Ok(facility);
        }

        [HttpPost("/Facility/Add")]
        [Authorize(Policy = APIPolicies.AdminPolicy)]
        public async Task<IActionResult> CreateFacilityHotel([FromBody] FacilityPostModel facilityCostRequestViewModel)
        {
            var facilityCost = _mapper.Map<FacilityPostModel, FacilityRequestModel>(facilityCostRequestViewModel);

            var createdEntity = await _additionalFacilityService.CreateAsync(facilityCost);

            var facility = _mapper.Map<AdditionalFacilityModel, AdditionalFacilityViewModel>(createdEntity);

            return Ok(facility);
        }

        /*[HttpPut("/Facility/Edit/{CityId}")]
        [Authorize(Policy = APIPolicies.AdminPolicy)]
        public async Task<IActionResult> UpdateFacilityHotel([FromBody] FacilityPutModel facilityCostPutModel)
        {
            var facilityCost = _mapper.Map<FacilityPutModel, FacilityPatchRequestModel>(facilityCostPutModel);

            await _facilityCostService.UpdateAsync(facilityCost);

            return NoContent();
        }*/
        
        [HttpGet("/Hotels/{hotelId}/GetFacilities")]
        public async Task<IActionResult> GetFacilities([FromQuery] AdditionalFacilityQueryModel queryModel)
        {
            var models = await _additionalFacilityService.GetListAsync(queryModel);
            var result = _mapper.Map<IList<AdditionalFacilityModel>, IList<AdditionalFacilityViewModel>>(models);
            return Ok(result);
        }

        [HttpGet()]
        [Route("GetFacilitiesRange")]
        public async Task<IActionResult> GetFacilitiesRange([FromQuery(Name = "facilitiesIds[]")] int[] facilitiesIds)
        {
            var facilities = await _additionalFacilityService.GetFacilitiesOrdersRange(facilitiesIds);
            var result = _mapper.Map<List<AdditionalFacilityOrderModel>, List<AdditionFacilityOrderViewModel>>(facilities);

            return Ok(result);
        }
    }
}
