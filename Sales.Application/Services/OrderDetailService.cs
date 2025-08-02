using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Application.Services
{
    public class OrderDetailService(IRepository<OrderDetail> repository) : IOrderDetailService
    {
        public async Task<IEnumerable<OrderDetail>> GetAllAsync() => await repository.GetAllAsync();

        public async Task<OrderDetail?> GetByIdAsync(int id) => await repository.GetByIdAsync(id);

        public async Task AddAsync(OrderDetail entity)
        {
            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderDetail entity)
        {
            repository.Update(entity);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(OrderDetail entity)
        {
            repository.Remove(entity);
            await repository.SaveChangesAsync();
        }
    }
}
