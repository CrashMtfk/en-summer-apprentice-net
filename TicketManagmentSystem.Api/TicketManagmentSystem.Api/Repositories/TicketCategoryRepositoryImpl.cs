using Microsoft.EntityFrameworkCore;
using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repositories
{
    public class TicketCategoryRepositoryImpl : ITicketCategoryRepository
    {
        private readonly PracticaContext _dbContext;
        public TicketCategoryRepositoryImpl()
        {
            _dbContext = new PracticaContext();
        }
        public async Task<TicketCategory> GetTicketCategoryById(int? id)
        {
            var ticketCategoryEntity = await _dbContext.TicketCategories
                                                        .Where(e => e.TicketCategoryId == id)
                                                        .FirstOrDefaultAsync();
            return ticketCategoryEntity;
        }
    }
}
