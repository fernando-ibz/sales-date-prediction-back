using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Application.Services
{
    public class CategoryService(IRepository<Category> repository) : ICategoryService
    {
        public async Task<IEnumerable<Category>> GetAllAsync() => await repository.GetAllAsync();

        public async Task<Category?> GetByIdAsync(int id) => await repository.GetByIdAsync(id);

        public async Task AddAsync(Category entity)
        {
            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category entity)
        {
            repository.Update(entity);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category entity)
        {
            repository.Remove(entity);
            await repository.SaveChangesAsync();
        }
    }
}
