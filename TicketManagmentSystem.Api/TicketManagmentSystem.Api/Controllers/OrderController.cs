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
        private readonly ITicketCategoryRepository ticketCategoryRepository;
        private readonly IMapper mapper;
        public OrderController(IOrderRepository orderRepository,ITicketCategoryRepository ticketCategoryRepository ,IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
            this.ticketCategoryRepository = ticketCategoryRepository;
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
        public ActionResult<OrderDto> GetOrderById(int id)
        {
            var order = orderRepository.GetById(id);
            if(order == null)
            {
                return NotFound();
            }

            var dtoOrder = mapper.Map<OrderDto>(order);
            return Ok(dtoOrder);
        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> UpdateOrder(OrderPatchDto orderPatch)
        {
            var orderEntity = await orderRepository.GetByIdForUpdateAndDelete(orderPatch.OrderId);
            var ticketCategoryEntity = await ticketCategoryRepository.GetTicketCategoryById(orderPatch.TicketCategoryID);
            if (orderEntity == null || ticketCategoryEntity == null)
            {
                return NotFound();
            }
            decimal totalPriceOfNewOrder = (decimal)(ticketCategoryEntity.Price * orderPatch.NumberOfTickets);
            orderEntity.TotalPrice = totalPriceOfNewOrder;
            mapper.Map(orderPatch, orderEntity);
            orderRepository.UpdateOrder(orderEntity);
            return Ok(orderEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var orderEntity = await orderRepository.GetByIdForUpdateAndDelete(id);
            if(orderEntity == null)
            {
                return NotFound();
            }
            orderRepository.DeleteOrder(orderEntity);
            return NoContent();
        }
    }
}
