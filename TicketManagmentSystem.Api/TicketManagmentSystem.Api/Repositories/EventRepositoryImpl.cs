using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repositories
{
    public class EventRepositoryImpl : IEventRepository
    {
        private readonly PracticaContext _dbContext;

        public EventRepositoryImpl()
        {
            _dbContext = new PracticaContext();
        }

        public int Add(Event toAddEvent)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events;
            return events;
        }

        public Event GetById(int id)
        {
            var @event = _dbContext.Events.Where(e => e.EventId == id).FirstOrDefault();
            return @event;
        }

        public void Update(Event toUpdateEvent)
        {
            throw new NotImplementedException();
        }
    }
}
