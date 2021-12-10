using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Response;
using HotelReservationSystemAPI.Constants;
using HotelReservationSystemAPI.Models.RequestModels;
using HotelReservationSystemAPI.Models.ResponseModels;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Policy = APIPolicies.AdminPolicy)]
        public async Task<IActionResult> CreateRoomType([FromQuery] RoomTypePostModel roomTypeViewModel)
        {
            var model = _mapper.Map<RoomTypePostModel, RoomTypeRequestModel>(roomTypeViewModel);

            var createdRoomType = await _roomTypeService.CreateAsync(model);

            var result = _mapper.Map<RoomTypeResponseModel, RoomTypeViewModel>(createdRoomType);

            return Ok(result);
        }

        [HttpGet("/Admin/{hotelId}")]
        [Authorize(Policy = APIPolicies.AdminPolicy)]
        public async Task<IActionResult> GetRoomTypes(int hotelId)
        {
            var models = await _roomTypeService.GetListAsync(hotelId);

            var result = _mapper.Map<IEnumerable<RoomTypeResponseModel>, IEnumerable<RoomViewModel>>(models);

            return Ok(result);
        }
    }
}
