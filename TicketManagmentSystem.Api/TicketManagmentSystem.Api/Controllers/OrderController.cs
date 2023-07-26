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
        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var orders = orderRepository.GetAll();

            if(orders == null)
            {
                return NotFound();
            }

            var dtoOrders = orders.Select(x => new OrderDto
            {
                OrderId = x.OrderId,
                OrderedAt = x.OrderedAt,
                NumberOfTickets = x.NumberOfTickets,
                TotalPrice = x.TotalPrice,
                Customer = x.Customer,
                TicketCategory = x.TicketCategory,
            });

            return Ok(dtoOrders);
        }
    }
}
