using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservationSystemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        public HotelsController(IMapper mapper, IHotelService hotelService, IRoomService roomService)
        {
            _hotelService = hotelService;
            _roomService = roomService;
            _mapper = mapper;
        }

        private readonly IHotelService _hotelService;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        [HttpGet("/Hotels")]
        public async Task<IEnumerable<HotelViewModel>> Get([FromQuery] HotelFreeSeatsQueryModel queryModel)
        {
            var models = await _hotelService.GetListAsync(queryModel);

            return _mapper.Map<IList<HotelModel>, IList<HotelViewModel>>(models);
        }

        [HttpGet("/Hotels/{hotelId}")]
        public async Task<IEnumerable<RoomViewModel>> GetHotelRooms([FromQuery] FreeRoomsQueryModel queryModel)
        {
            var models = await _roomService.GetListAsync(queryModel);

            return _mapper.Map<IList<RoomModel>, IList<RoomViewModel>>(models);
        }
    }
}
