using Sales.Domain.Entities;

namespace Sales.Domain.Interfaces
{
    public interface ISupplierService
    {
        Task AddAsync(Supplier entity);
        Task DeleteAsync(Supplier entity);
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<Supplier?> GetByIdAsync(int id);
        Task UpdateAsync(Supplier entity);
    }
}
