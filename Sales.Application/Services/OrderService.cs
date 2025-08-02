using Sales.Domain.DTOs;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Application.Services
{
    public class OrderService(IRepository<Order> repository) : IOrderService
    {
        public async Task<IEnumerable<Order>> GetAllAsync() => await repository.GetAllAsync();

        public async Task<Order?> GetByIdAsync(int id) => await repository.GetByIdAsync(id);

        public async Task AddAsync(Order entity)
        {
            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order entity)
        {
            repository.Update(entity);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order entity)
        {
            repository.Remove(entity);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderNextPredictedDto>> GetAllOrderNextPredictedAsync()
        {
            return [];
        }
    }
}
