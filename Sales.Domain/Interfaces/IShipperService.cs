using Sales.Domain.Entities;

namespace Sales.Domain.Interfaces
{
    public interface IShipperService
    {
        Task AddAsync(Shipper entity);
        Task DeleteAsync(Shipper entity);
        Task<IEnumerable<Shipper>> GetAllAsync();
        Task<Shipper?> GetByIdAsync(int id);
        Task UpdateAsync(Shipper entity);
    }
}
