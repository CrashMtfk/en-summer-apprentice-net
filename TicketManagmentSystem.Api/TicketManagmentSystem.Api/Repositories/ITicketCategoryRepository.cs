using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repositories
{
    public interface ITicketCategoryRepository
    {
        Task<TicketCategory> GetTicketCategoryById(int ?id);
    }
}
