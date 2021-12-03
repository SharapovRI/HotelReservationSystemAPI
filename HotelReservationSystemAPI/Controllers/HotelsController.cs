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
            var (models, pageCount) = await _hotelService.GetListAsync(queryModel);

            var result = _mapper.Map<IList<HotelModel>, IList<HotelViewModel>>(models);

            return Ok(new { result, pageCount });
        }

        [HttpPost("/Hotel/Create")]
        public async Task<IActionResult> CreateHotel([FromBody] HotelPostModel hotelRequestModel)
        {
            var hotel = _mapper.Map<HotelPostModel, HotelRequestModel>(hotelRequestModel);

            var createdHotel = await _hotelService.CreateAsync(hotel);

            var hotelViewModel = _mapper.Map<HotelModel, HotelViewModel>(createdHotel);

            return Ok(hotelViewModel);
        }

        [HttpPut("/Hotel/Edit/{hotelId}")]
        public async Task<IActionResult> UpdateHotel([FromBody] HotelPutModel hotelPatchModel)
        {
            var hotel = _mapper.Map<HotelPutModel, HotelRequestModel>(hotelPatchModel);

            await _hotelService.UpdateAsync(hotel);

            return NoContent();
        }
    }
}
