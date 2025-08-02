using Sales.Domain.Entities;

namespace Sales.Domain.Interfaces
{
    public interface ICategoryService
    {
        Task AddAsync(Category entity);
        Task DeleteAsync(Category entity);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task UpdateAsync(Category entity);
    }
}
