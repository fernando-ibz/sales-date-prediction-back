using Sales.Domain.Entities;

namespace Sales.Domain.Interfaces
{
    public interface IEmployeeService
    {
        Task AddAsync(Employee entity);
        Task DeleteAsync(Employee entity);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task UpdateAsync(Employee entity);
    }
}
