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
        public HotelsController(IMapper mapper, IHotelService hotelService)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }

        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        [HttpGet]
        public async Task<IEnumerable<HotelViewModel>> Get([FromQuery] HotelFreeSeatsQueryModel queryModel)
        {
            var models = await _hotelService.GetListAsync(queryModel);

            return _mapper.Map<IList<HotelModel>, IList<HotelViewModel>>(models);
        }
    }
}
