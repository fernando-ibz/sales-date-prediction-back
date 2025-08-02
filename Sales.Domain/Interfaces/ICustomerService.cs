using Sales.Domain.Entities;

namespace Sales.Domain.Interfaces
{
    public interface ICustomerService
    {
        Task AddAsync(Customer entity);
        Task DeleteAsync(Customer entity);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task UpdateAsync(Customer entity);
    }
}
