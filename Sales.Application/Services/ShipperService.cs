using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Application.Services
{
    public class ShipperService(IRepository<Shipper> repository) : IShipperService
    {
        public async Task<IEnumerable<Shipper>> GetAllAsync() => await repository.GetAllAsync();

        public async Task<Shipper?> GetByIdAsync(int id) => await repository.GetByIdAsync(id);

        public async Task AddAsync(Shipper entity)
        {
            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Shipper entity)
        {
            repository.Update(entity);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Shipper entity)
        {
            repository.Remove(entity);
            await repository.SaveChangesAsync();
        }
    }
}
