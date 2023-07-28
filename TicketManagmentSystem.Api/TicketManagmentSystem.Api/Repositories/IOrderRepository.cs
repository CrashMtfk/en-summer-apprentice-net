﻿using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Task<Order> GetById(int id);
        Task<Order> GetByIdForUpdateAndDelete(int id);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
