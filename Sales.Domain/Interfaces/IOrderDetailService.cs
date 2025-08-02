using Sales.Domain.Entities;

namespace Sales.Domain.Interfaces
{
    public interface IOrderDetailService
    {
        Task AddAsync(OrderDetail entity);
        Task DeleteAsync(OrderDetail entity);
        Task<IEnumerable<OrderDetail>> GetAllAsync();
        Task<OrderDetail?> GetByIdAsync(int id);
        Task UpdateAsync(OrderDetail entity);
    }
}
