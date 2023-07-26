using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repositories
{
    public class OrderRepositoryImpl : IOrderRepository
    {
        private readonly PracticaContext _dbContext;
        public OrderRepositoryImpl()
        {
            _dbContext = new PracticaContext();
        }
        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders;
            return orders;
        }

        public Order GetById(int id)
        {
            var order = _dbContext.Orders.Where(e => e.OrderId == id).FirstOrDefault();
            return order;
        }
    }
}
