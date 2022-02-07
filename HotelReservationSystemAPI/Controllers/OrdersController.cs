using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Models.RequestModels;
using HotelReservationSystemAPI.Models.ResponseModels;
using HotelReservationSystemAPI.Business.Models.Response;
using HotelReservationSystemAPI.Business.Models.Request;

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

        [HttpPost("/Order/Create")] //TODO take id from token
        public async Task<IActionResult> CreateOrder([FromBody] OrderGroupPostModel orderViewModel)
        {
            var model = _mapper.Map<OrderGroupPostModel, OrderGroupModel>(orderViewModel);

            await _orderService.CreateGroupOrder(model);

            return Ok();
        }

        [HttpGet("/Hotels/GetMyOrders")]
        public async Task<IActionResult> GetMyOrders([FromQuery] OrderQueryModel queryModel)
        {
            var (models, pageCount) = await _orderService.GetListAsync(queryModel);

            var result = _mapper.Map<IList<OrderGroupResponseModel>, IList<OrderGroupViewModel>>(models);

            return Ok(new {result, pageCount});
        }

        [HttpPut("/Order/UpdateTime")]
        public async Task<IActionResult> UpdateArrivalTime([FromBody] OrderUpdateTimeModel orderUpdateTimeModel)
        {
            var model = _mapper.Map<OrderUpdateTimeModel, OrderTimeUpdateModel>(orderUpdateTimeModel);
            await _orderService.UpdateArrivalTime(model);
            return Ok();
        }

        [AcceptVerbs("Post")]
        public bool CheckTime(DateTimeOffset dateTime)
        {
            return dateTime >= DateTimeOffset.Now;
        }
    }
}
