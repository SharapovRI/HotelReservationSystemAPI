using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Models.RequestModels;

namespace HotelReservationSystemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrdersController(IMapper mapper, IOrderService orderService)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost("/Hotels/Create")]
        public async Task<IActionResult> CreateOrder([FromQuery] OrderPostModel orderViewModel)
        {
            var model = _mapper.Map<OrderPostModel, OrderModel>(orderViewModel);

            await _orderService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("/Hotels/GetMyOrders")]
        public async Task<IActionResult> GetMyOrders([FromQuery] OrderQueryModel queryModel)
        {
            var models = await _orderService.GetListAsync(queryModel);

            var result = _mapper.Map<IList<OrderModel>, IList<OrderPostModel>>(models);

            return Ok(result);
        }
    }
}
