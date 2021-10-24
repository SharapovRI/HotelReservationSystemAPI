using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservationSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsSearchController : ControllerBase
    {
        public HotelsSearchController(IMapper mapper, ILocateService locateService)
        {
            _locateService = locateService;
            _mapper = mapper;
        }

        private readonly ILocateService _locateService;
        private readonly IMapper _mapper;

        [HttpGet]
        public async Task<IEnumerable<LocateViewModel>> GetLocates()
        {
            var locates = await _locateService.GetListAsync();
            return _mapper.Map<IEnumerable<LocateModel>, IEnumerable<LocateViewModel>>(locates);
        }
    }
}
