using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Models;

namespace HotelReservationSystemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public AdminController(IMapper mapper, IRoomTypeService roomTypeService, IHotelService hotelService,
            IAdditionalFacilityService additionalFacilityService, IFacilityCostService facilityCostService)
        {
            //_orderService = orderService;
            _hotelService = hotelService;
            _additionalFacilityService = additionalFacilityService;
            //_roomService = roomService;
            _facilityCostService = facilityCostService;
            _roomTypeService = roomTypeService;
            _mapper = mapper;
        }

        //private readonly IOrderService _orderService;
        private readonly IHotelService _hotelService;
        //private readonly IRoomService _roomService;
        private readonly IFacilityCostService _facilityCostService;
        private readonly IAdditionalFacilityService _additionalFacilityService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IMapper _mapper;

        [HttpPost("/RoomType/Create")]
        public async Task<RoomTypeViewModel> CreateRoomType([FromQuery] RoomTypeViewModel roomTypeViewModel)
        {
            var model = _mapper.Map<RoomTypeViewModel, RoomTypeModel>(roomTypeViewModel);

            await _roomTypeService.CreateAsync(model);

            return roomTypeViewModel;
        }

        [HttpGet("/Admin/{hotelId}")]
        public async Task<IEnumerable<RoomTypeViewModel>> Get(int hotelId)
        {
            var models = await _roomTypeService.GetListAsync(hotelId);

            return _mapper.Map<IEnumerable<RoomTypeModel>, IEnumerable<RoomTypeViewModel>>(models);
        }

        [HttpPost("/Hotel/Create")]
        public async Task CreateHotel([FromBody] HotelRequestViewModel hotelRequestModel)
        {
            var hotel = _mapper.Map<HotelRequestViewModel, HotelRequestModel>(hotelRequestModel);

            await _hotelService.CreateAsync(hotel);
        }

        [HttpPost("/Facility/Create")]
        public async Task CreateFacility([FromBody] FacilityRequestViewModel facilityRequestViewModel)
        {
            var facility = _mapper.Map<FacilityRequestViewModel, FacilityRequestModel>(facilityRequestViewModel);

            await _additionalFacilityService.CreateAsync(facility);
        }

        [HttpPost("/Facility/Add")]
        public async Task CreateFacilityHotel([FromBody] FacilityCostRequestViewModel facilityCostRequestViewModel)
        {
            var facilityCost = _mapper.Map<FacilityCostRequestViewModel, FacilityRequestCostModel>(facilityCostRequestViewModel);

            await _facilityCostService.CreateAsync(facilityCost);
        }
    }
}
