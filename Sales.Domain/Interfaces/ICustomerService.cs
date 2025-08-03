using Sales.Domain.DTOs;
using Sales.Domain.Entities;

namespace Sales.Domain.Interfaces
{
    public interface ICustomerService
    {
        Task AddAsync(Customer entity);
        Task DeleteAsync(Customer entity);
        Task<IEnumerable<CustomerResponseDto>> GetAllAsync();
        Task<IEnumerable<CustomerResponseDto>> GetAllByCustomerName(string customerName);
        Task<Customer?> GetByIdAsync(int id);
        Task UpdateAsync(Customer entity);
    }
}
