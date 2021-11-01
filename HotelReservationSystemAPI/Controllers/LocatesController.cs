using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Models.ResponseModels;

namespace HotelReservationSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocatesController : ControllerBase
    {
        private readonly ILocateService _locateService;
        private readonly IMapper _mapper;

        public LocatesController(IMapper mapper, ILocateService locateService)
        {
            _locateService = locateService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocates()
        {
            var locates = await _locateService.GetListAsync();

            var result = _mapper.Map<IEnumerable<LocateModel>, IEnumerable<LocateViewModel>>(locates);

            return Ok(result);
        }
    }
}
