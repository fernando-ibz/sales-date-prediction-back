using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Application.Services
{
    public class SupplierService(IRepository<Supplier> repository) : ISupplierService
    {
        public async Task<IEnumerable<Supplier>> GetAllAsync() => await repository.GetAllAsync();

        public async Task<Supplier?> GetByIdAsync(int id) => await repository.GetByIdAsync(id);

        public async Task AddAsync(Supplier entity)
        {
            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Supplier entity)
        {
            repository.Update(entity);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Supplier entity)
        {
            repository.Remove(entity);
            await repository.SaveChangesAsync();
        }
    }
}
