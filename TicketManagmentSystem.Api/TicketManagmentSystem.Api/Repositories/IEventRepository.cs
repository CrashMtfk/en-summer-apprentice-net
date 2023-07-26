using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Event GetById(int id);
        int Add(Event toAddEvent);
        void Update(Event toUpdateEvent);
        int Delete(int id);
    }
}
