using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Models.RequestModels;
using HotelReservationSystemAPI.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservationSystemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomsController(IMapper mapper, IRoomService roomService)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet("/Hotels/{hotelId}")]
        public async Task<IActionResult> GetHotelRooms([FromQuery] FreeRoomsQueryModel queryModel)
        {
            var models = await _roomService.GetListAsync(queryModel);

            var result = _mapper.Map<IList<RoomModel>, IList<RoomViewModel>>(models);

            return Ok(result);
        }

        [HttpPut("/Hotel/Edit/{Id}")]
        public async Task<IActionResult> UpdateRoom([FromBody] RoomPutModel roomPutModel)
        {
            var roomModel = _mapper.Map<RoomPutModel, RoomModel>(roomPutModel);

            await _roomService.UpdateAsync(roomModel);

            return NoContent();
        }

        //TODO Create updating room state
    }
}
