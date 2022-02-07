using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Models.RequestModels;
using HotelReservationSystemAPI.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.Models.Response;
using HotelReservationSystemAPI.Constants;
using Microsoft.AspNetCore.Authorization;

namespace HotelReservationSystemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IHotelService _hotelService;
        private readonly IRoomPhotoService _roomPhotoService;
        private readonly IMapper _mapper;

        public RoomsController(IMapper mapper, IRoomService roomService, IHotelService hotelService, IRoomPhotoService roomPhotoService)
        {
            _roomPhotoService = roomPhotoService;
            _roomService = roomService;
            _hotelService = hotelService;
            _mapper = mapper;
        }

        /*[HttpGet("/Hotels/{hotelId}")]
        public async Task<IActionResult> GetHotelRooms([FromQuery] FreeRoomsQueryModel queryModel)
        {
            var (rooms, pageCount) = await _roomService.GetListAsync(queryModel);

            var hotel = await _hotelService.GetAsync(queryModel.HotelId); //TODO view model

            var result = _mapper.Map<IList<RoomModel>, IList<RoomViewModel>>(rooms);

            return Ok(new {result, hotel, pageCount});
        }*/

        [HttpGet("/Hotels/{hotelId}")]
        public async Task<IActionResult> GetHotelRooms([FromQuery] FreeRoomsQueryModel queryModel)
        {
            var (rooms, pageCount) = await _roomService.GetListAsync(queryModel);

            var hotel = await _hotelService.GetAsync(queryModel.HotelId); //TODO view model

            var result = _mapper.Map<IList<RoomGroupModel>, IList<RoomGroupViewModel>>(rooms);

            return Ok(new { result, hotel, pageCount });
        }

        [HttpPut("/Hotel/Room/Edit/{roomId}")]
        [Authorize(Policy = APIPolicies.AdminPolicy)]
        public async Task<IActionResult> UpdateRoom([FromBody] RoomPutModel roomPutModel)
        {
            var roomModel = _mapper.Map<RoomPutModel, RoomUpdateModel>(roomPutModel);

            await _roomService.UpdateAsync(roomModel);

            return NoContent();
        }

        [HttpGet("Rooms/{roomId}")]
        public async Task<IActionResult> GetRoom(int roomId)
        {
            var (room, hotelId) = await _roomService.GetRoom(roomId); 
            var result = _mapper.Map<RoomModel, RoomViewModel>(room);

            return Ok(new { result, hotelId });
        }

        [HttpGet()]
        [Route("GetRoomsRange")]
        public async Task<IActionResult> GetRoomsRange([FromQuery(Name = "roomsIds[]")] int[] roomsIds)
        {
            var (rooms, hotelId) = await _roomService.GetRoomsRange(roomsIds);
            var result = _mapper.Map<List<RoomModel>, List<RoomViewModel>>(rooms);

            return Ok(new { result, hotelId });
        }

        /*[HttpPost("/Rooms/UploadPhoto")]
        public async Task<IActionResult> UploadPhotos([FromBody]RoomPhotoListPostModel photos)
        {
            var photoList = _mapper.Map<RoomPhotoListPostModel, RoomPhotosCreationListModel>(photos);
            var result = await _roomPhotoService.CreateAsync(photoList);
            return Ok(result);
        }*/

        //TODO Create updating room state
    }
}
