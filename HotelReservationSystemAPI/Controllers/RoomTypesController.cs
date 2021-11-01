using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Models.RequestModels;
using HotelReservationSystemAPI.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoomTypesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypesController(IMapper mapper, IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
            _mapper = mapper;
        }

        [HttpPost("/RoomType/Create")]
        public async Task<IActionResult> CreateRoomType([FromQuery] RoomTypePostModel roomTypeViewModel)
        {
            var model = _mapper.Map<RoomTypePostModel, RoomTypeModel>(roomTypeViewModel);

            await _roomTypeService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("/Admin/{hotelId}")]
        public async Task<IActionResult> GetRoomTypes(int hotelId)
        {
            var models = await _roomTypeService.GetListAsync(hotelId);

            var result = _mapper.Map<IEnumerable<RoomTypeModel>, IEnumerable<RoomTypeModel>>(models);

            return Ok(result);
        }
    }
}
