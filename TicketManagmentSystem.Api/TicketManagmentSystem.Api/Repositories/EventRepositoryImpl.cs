using Microsoft.EntityFrameworkCore;
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

        public void Delete(Event @event)
        {
            _dbContext.Remove(@event);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events;
            return events;
        }

        public async Task<Event> GetById(int id)
        {
            var @event = await _dbContext.Events.Where(e => e.EventId == id).FirstOrDefaultAsync();
            return @event;
        }

        public void Update(Event toUpdateEvent)
        {
            _dbContext.Entry(toUpdateEvent).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
