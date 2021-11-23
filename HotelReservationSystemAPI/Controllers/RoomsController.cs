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
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public RoomsController(IMapper mapper, IRoomService roomService, IHotelService hotelService)
        {
            _roomService = roomService;
            _hotelService = hotelService;
            _mapper = mapper;
        }

        [HttpGet("/Hotels/{hotelId}")]
        public async Task<IActionResult> GetHotelRooms([FromQuery] FreeRoomsQueryModel queryModel)
        {
            var (rooms, pageCount) = await _roomService.GetListAsync(queryModel);

            var hotel = await _hotelService.GetAsync(queryModel.HotelId); //TODO view model

            var result = _mapper.Map<IList<RoomModel>, IList<RoomViewModel>>(rooms);

            return Ok(new {result, hotel, pageCount});
        }

        [HttpPut("/Hotel/Room/Edit/{Id}")]
        public async Task<IActionResult> UpdateRoom([FromBody] RoomPutModel roomPutModel)
        {
            var roomModel = _mapper.Map<RoomPutModel, RoomModel>(roomPutModel);

            await _roomService.UpdateAsync(roomModel);

            return NoContent();
        }

        [HttpGet("/Hotels/{hotelId}/Rooms/{roomId}")]
        public async Task<IActionResult> GetRoom(int hotelId, int roomId)
        {
            var room = await _roomService.GetRoom(roomId, hotelId); 
            var result = _mapper.Map<RoomModel, RoomViewModel>(room);

            return Ok(result);
        }

        //TODO Create updating room state
    }
}
