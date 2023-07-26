using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManagmentSystem.Api.Models;
using TicketManagmentSystem.Api.Models.Dto;
using TicketManagmentSystem.Api.Repositories;

namespace TicketManagmentSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;
        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var orders = orderRepository.GetAll();

            if(orders == null)
            {
                return NotFound();
            }

            var dtoOrders = orders.Select(x => mapper.Map<OrderDto>(x));

            return Ok(dtoOrders);
        }

        [HttpGet]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = orderRepository.GetById(id);
            if(order == null)
            {
                return NotFound();
            }

            var dtoOrder = mapper.Map<OrderDto>(order);
            return Ok(dtoOrder);
        }
    }
}
