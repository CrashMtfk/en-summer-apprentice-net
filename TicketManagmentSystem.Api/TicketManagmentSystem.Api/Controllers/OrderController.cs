using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManagmentSystem.Api.BusinessLogic;
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
        private readonly OrderService orderService;
        private readonly ITicketCategoryRepository ticketCategoryRepository;
        private readonly IMapper mapper;
        public OrderController(IOrderRepository orderRepository,
                                ITicketCategoryRepository ticketCategoryRepository,
                                IMapper mapper,
                                OrderService orderService)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
            this.ticketCategoryRepository = ticketCategoryRepository;
            this.orderService = orderService;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var dtoOrders = orderService.GetAll();

            if(dtoOrders == null)
            {
                return NotFound();
            }
            return Ok(dtoOrders);
        }

        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetOrderById(int id)
        {
            var dtoOrder = await orderService.GetOrderById(id);
            if(dtoOrder == null)
            {
                return NotFound();
            }
            return Ok(dtoOrder);
        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> UpdateOrder(OrderPatchDto orderPatch)
        {
            var orderEntity = await orderService.UpdateOrder(orderPatch);
            if (orderEntity == null)
            {
                return NotFound();
            }
            return Ok(orderEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var deletedEntityDto = await orderService.DeleteOrder(id);
            if(deletedEntityDto == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
