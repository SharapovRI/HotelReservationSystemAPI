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
            var facility = _mapper.Map<FacilityPostModel, FacilityRequestModel>(facilityRequestViewModel);

            await _additionalFacilityService.CreateAsync(facility);

            return Ok();
        }

        [HttpPost("/Facility/Add")]
        public async Task<IActionResult> CreateFacilityHotel([FromBody] FacilityCostPostModel facilityCostRequestViewModel)
        {
            var facilityCost = _mapper.Map<FacilityCostPostModel, FacilityRequestCostModel>(facilityCostRequestViewModel);

            await _facilityCostService.CreateAsync(facilityCost);

            return Ok();
        }

        [HttpPut("/Facility/Edit/{Id}")]
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
