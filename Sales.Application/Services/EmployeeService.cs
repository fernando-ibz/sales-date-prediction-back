using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Application.Services
{
    public class EmployeeService(IRepository<Employee> repository) : IEmployeeService
    {
        public async Task<IEnumerable<Employee>> GetAllAsync() => await repository.GetAllAsync();

        public async Task<Employee?> GetByIdAsync(int id) => await repository.GetByIdAsync(id);

        public async Task AddAsync(Employee entity)
        {
            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee entity)
        {
            repository.Update(entity);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee entity)
        {
            repository.Remove(entity);
            await repository.SaveChangesAsync();
        }
    }
}
