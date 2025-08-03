using Microsoft.Data.SqlClient;
using Sales.Domain.DTOs;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using System.Data;

namespace Sales.Application.Services
{
    public class OrderService(IRepository<Order> repository) : IOrderService
    {
        public async Task<IEnumerable<Order>> GetAllAsync() => await repository.GetAllAsync();

        public async Task<Order?> GetByIdAsync(int id) => await repository.GetByIdAsync(id);

        public async Task AddAsync(Order entity)
        {
            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order entity)
        {
            repository.Update(entity);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order entity)
        {
            repository.Remove(entity);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderNextPredictedDto>> GetAllOrderNextPredictedAsync(string? customerIds = null)
        {
            List<SqlParameter> parameters = [
                new SqlParameter
                {
                    ParameterName = "@custids",
                    SqlDbType = SqlDbType.NVarChar, 
                    Value = string.IsNullOrEmpty(customerIds) ? DBNull.Value : customerIds, 
                    Size = -1 
                }
                ];

            return await repository.ExecuteStoredProcedureAsync<OrderNextPredictedDto>("EXEC Sales.usp_GetNextOrderPrediction @custids", [.. parameters]);
        }

        public async Task<IEnumerable<Order>> GetAllbyCustomer(int customerId)
            => await repository.FindAsync(o => o.CustId == customerId);
    }
}
