using Sales.Domain.Entities;

namespace Sales.Domain.Interfaces
{
    public interface ICustomerService
    {
        Task AddAsync(Customer customer);
        Task DeleteAsync(Customer customer);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task UpdateAsync(Customer customer);
    }
}
