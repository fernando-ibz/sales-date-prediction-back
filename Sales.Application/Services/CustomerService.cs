using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Application.Services
{
    public class CustomerService(IRepository<Customer> customerRepository) : ICustomerService
    {
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await customerRepository.GetAllAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await customerRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Customer customer)
        {
            await customerRepository.AddAsync(customer);
            await customerRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            customerRepository.Update(customer);
            await customerRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer customer)
        {
            customerRepository.Remove(customer);
            await customerRepository.SaveChangesAsync();
        }
    }
}

