using Sales.Domain.DTOs;
using Sales.Domain.Entities;

namespace Sales.Domain.Interfaces
{
    public interface IOrderService
    {
        Task AddAsync(Order entity);
        Task DeleteAsync(Order entity);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task UpdateAsync(Order entity);
        Task<IEnumerable<Order>> GetAllbyCustomer(int customerId);
        Task<IEnumerable<OrderNextPredictedDto>> GetAllOrderNextPredictedAsync(string? customerIds = null);
    }
}
