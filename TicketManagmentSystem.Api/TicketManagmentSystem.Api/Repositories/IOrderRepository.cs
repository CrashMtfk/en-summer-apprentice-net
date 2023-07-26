using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
    }
}
