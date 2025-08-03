using AutoMapper;
using Sales.Domain.DTOs;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Application.Services
{
    public class CustomerService(IRepository<Customer> repository, IOrderService orderService, IMapper mapper) : ICustomerService
    {
        public async Task<IEnumerable<CustomerResponseDto>> GetAllAsync()
        {
            IEnumerable<Customer> customers = await repository.GetAllAsync();
            IEnumerable<OrderNextPredictedDto> orders = await orderService.GetAllOrderNextPredictedAsync();
            IEnumerable<CustomerResponseDto> result = mapper.Map<IEnumerable<CustomerResponseDto>>(customers);

            return JoinOrderNextPredicted(orders, result);
        }

        private static IEnumerable<CustomerResponseDto> JoinOrderNextPredicted(IEnumerable<OrderNextPredictedDto> orders, IEnumerable<CustomerResponseDto> result)
        {
            foreach (CustomerResponseDto customer in result)
            {
                OrderNextPredictedDto? order = orders.FirstOrDefault(o => o.CustId == customer.CustId);

                if (order == null)
                    continue;

                customer.LastOrderDate = order.LastOrderDate;
                customer.NextPredictedOrder = order.NextPredictedOrder;
            }

            return result.OrderBy(c => c.CompanyName);
        }

        public async Task<Customer?> GetByIdAsync(int id) => await repository.GetByIdAsync(id);

        public async Task AddAsync(Customer entity)
        {
            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer entity)
        {
            repository.Update(entity);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer entity)
        {
            repository.Remove(entity);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomerResponseDto>> GetAllByCustomerName(string customerName)
        {
            IEnumerable<Customer> customers = await repository.FindAsync(c => c.CompanyName.Contains(customerName));

            if (!customers.Any())
                return [];

            IEnumerable<OrderNextPredictedDto> orders = await orderService.GetAllOrderNextPredictedAsync(
                string.Join(",", customers.Select(c => c.CustId))
                );
            IEnumerable<CustomerResponseDto> result = mapper.Map<IEnumerable<CustomerResponseDto>>(customers);

            return JoinOrderNextPredicted(orders, result);
        }
    }
}
