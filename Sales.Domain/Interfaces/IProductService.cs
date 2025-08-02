using Sales.Domain.Entities;

namespace Sales.Domain.Interfaces
{
    public interface IProductService
    {
        Task AddAsync(Product entity);
        Task DeleteAsync(Product entity);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task UpdateAsync(Product entity);
    }
}
