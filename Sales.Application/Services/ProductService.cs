using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Application.Services
{
    public class ProductService(IRepository<Product> repository) : IProductService
    {
        public async Task<IEnumerable<Product>> GetAllAsync() => await repository.GetAllAsync();

        public async Task<Product?> GetByIdAsync(int id) => await repository.GetByIdAsync(id);

        public async Task AddAsync(Product entity)
        {
            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            repository.Update(entity);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product entity)
        {
            repository.Remove(entity);
            await repository.SaveChangesAsync();
        }
    }
}
