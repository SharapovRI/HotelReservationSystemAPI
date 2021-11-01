using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.QueryModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Models.RequestModels;
using HotelReservationSystemAPI.Models.ResponseModels;

namespace HotelReservationSystemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HotelsController(IMapper mapper, IHotelService hotelService)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }

        [HttpGet("/Hotels")]
        public async Task<IActionResult> Get([FromQuery] HotelFreeSeatsQueryModel queryModel)
        {
            var models = await _hotelService.GetListAsync(queryModel);

            var result = _mapper.Map<IList<HotelModel>, IList<HotelViewModel>>(models);

            return Ok(result);
        }

        [HttpPost("/Hotel/Create")]
        public async Task<IActionResult> CreateHotel([FromBody] HotelPostModel hotelRequestModel)
        {
            var hotel = _mapper.Map<HotelPostModel, HotelRequestModel>(hotelRequestModel);

            await _hotelService.CreateAsync(hotel);

            return Ok();
        }

        [HttpPut("/Hotel/Edit/{Id}")]
        public async Task<IActionResult> UpdateHotel([FromBody] HotelPutModel hotelPatchModel)
        {
            var facilityCost = _mapper.Map<HotelPutModel, HotelModel>(hotelPatchModel);

            await _hotelService.UpdateAsync(facilityCost);

            return NoContent();
        }
    }
}
