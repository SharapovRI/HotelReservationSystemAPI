using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Models.RequestModels;
using HotelReservationSystemAPI.Models.ResponseModels;

namespace HotelReservationSystemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdditionalFacilitiesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAdditionalFacilityService _additionalFacilityService;
        private readonly IFacilityCostService _facilityCostService;

        public AdditionalFacilitiesController(IMapper mapper, IAdditionalFacilityService additionalFacilityService, IFacilityCostService facilityCostService)
        {
            _additionalFacilityService = additionalFacilityService;
            _facilityCostService = facilityCostService;
            _mapper = mapper;
        }

        [HttpPost("/Facility/Create")]
        public async Task<IActionResult> CreateFacility([FromBody] FacilityPostModel facilityRequestViewModel)
        {
            var facilityRequestModel = _mapper.Map<FacilityPostModel, FacilityRequestModel>(facilityRequestViewModel);

            var createdEntity = await _additionalFacilityService.CreateAsync(facilityRequestModel);

            var facility = _mapper.Map<AdditionalFacilityModel, AdditionalFacilityViewModel>(createdEntity);

            return Ok(facility);
        }

        [HttpPost("/Facility/Add")]
        public async Task<IActionResult> CreateFacilityHotel([FromBody] FacilityCostPostModel facilityCostRequestViewModel)
        {
            var facilityCost = _mapper.Map<FacilityCostPostModel, FacilityRequestCostModel>(facilityCostRequestViewModel);

            var createdEntity = await _facilityCostService.CreateAsync(facilityCost);

            var facility = _mapper.Map<AdditionalFacilityModel, AdditionalFacilityViewModel>(createdEntity);

            return Ok(facility);
        }

        [HttpPut("/Facility/Edit/{CityId}")]
        public async Task<IActionResult> UpdateFacilityHotel([FromBody] FacilityCostPutModel facilityCostPutModel)
        {
            var facilityCost = _mapper.Map<FacilityCostPutModel, FacilityPatchRequestCostModel>(facilityCostPutModel);

            await _facilityCostService.UpdateAsync(facilityCost);

            return NoContent();
        }

        [HttpGet("/Hotels/{hotelId}/GetFacilities")]
        public async Task<IActionResult> GetFacilities([FromQuery] AdditionalFacilityQueryModel queryModel)
        {
            var models = await _facilityCostService.GetListAsync(queryModel);
            var result = _mapper.Map<IList<AdditionalFacilityModel>, IList<AdditionalFacilityViewModel>>(models);
            return Ok(result);
        }
    }
}
