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
        public HotelsController(IMapper mapper, IHotelService hotelService, IRoomService roomService, IFacilityCostService facilityCostService)
        {
            _hotelService = hotelService;
            _roomService = roomService;
            _facilityCostService = facilityCostService;
            _mapper = mapper;
        }

        private readonly IHotelService _hotelService;
        private readonly IRoomService _roomService;
        private readonly IFacilityCostService _facilityCostService;
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

        [HttpGet("/Hotels/{hotelId}/GetFacilities")]
        public async Task<IEnumerable<AdditionalFacilityViewModel>> GetFacilities([FromQuery] AdditionalFacilityQueryModel queryModel)
        {
            var models = await _facilityCostService.GetListAsync(queryModel);

            return _mapper.Map<IList<AdditionalFacilityModel>, IList<AdditionalFacilityViewModel>>(models);
        }
    }
}
