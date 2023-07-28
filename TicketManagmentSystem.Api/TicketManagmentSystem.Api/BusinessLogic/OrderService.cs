using AutoMapper;
using TicketManagmentSystem.Api.Models.Dto;
using TicketManagmentSystem.Api.Repositories;

namespace TicketManagmentSystem.Api.BusinessLogic
{
    public class OrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ITicketCategoryRepository ticketCategoryRepository;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository orderRepository, ITicketCategoryRepository ticketCategoryRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.ticketCategoryRepository = ticketCategoryRepository;
            this.mapper = mapper;
        }

        public List<OrderDto> GetAll()
        {
            var orders = orderRepository.GetAll();
            if(orders == null)
            {
                return null;
            }

            var dtoOrders = orders.Select(x => mapper.Map<OrderDto>(x)).ToList();
            return dtoOrders;
        }

        public async Task<OrderDto> GetOrderById(int id)
        {
            var order = await orderRepository.GetById(id);
            if(order == null)
            {
                return null;
            }
            var dtoOrder = mapper.Map<OrderDto>(order);
            return dtoOrder;
        }

        public async Task<OrderPatchDto> UpdateOrder(OrderPatchDto orderPatch)
        {
            var orderEntity = await orderRepository.GetById(orderPatch.OrderId);
            var ticketCategoryEntity = await ticketCategoryRepository.GetTicketCategoryById(orderPatch.TicketCategoryID);
            if (orderEntity == null || ticketCategoryEntity == null)
            {
                return null;
            }

            decimal totalPriceOfNewOrder = (decimal)(ticketCategoryEntity.Price * orderPatch.NumberOfTickets);
            orderEntity.TotalPrice = totalPriceOfNewOrder;
            mapper.Map(orderPatch, orderEntity);
            orderRepository.UpdateOrder(orderEntity);
            return orderPatch;
        }

        public async Task<OrderDto> DeleteOrder(int id)
        {
            var orderToDelete = await orderRepository.GetById(id);
            orderRepository.DeleteOrder(orderToDelete);
            var orderDto = mapper.Map<OrderDto>(orderToDelete);
            return orderDto;
        }
    }
}
