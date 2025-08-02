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
    }
}
