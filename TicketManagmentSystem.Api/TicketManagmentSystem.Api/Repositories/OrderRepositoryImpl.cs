using Microsoft.EntityFrameworkCore;
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
            var orders = _dbContext.Orders
                                    .Include(x => x.TicketCategory)
                                    .Include(x => x.Customer);
            return orders;
        }

        public Order GetById(int id)
        {
            var order = _dbContext.Orders.Include(x => x.TicketCategory)
                                            .Include(x => x.Customer)
                                            .Where(e => e.OrderId == id)
                                            .FirstOrDefault();
            return order;
        }

        public async Task<Order> GetByIdForUpdateAndDelete(int id)
        {
            var order = await _dbContext.Orders
                                            .Where(e => e.OrderId == id)
                                            .FirstOrDefaultAsync();
            return order;
        }


        public void UpdateOrder(Order toUpdateOrder)
        {
            _dbContext.Entry(toUpdateOrder).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteOrder(Order orderToDelete)
        {
            _dbContext.Remove(orderToDelete);
            _dbContext.SaveChanges();
        }
    }
}
