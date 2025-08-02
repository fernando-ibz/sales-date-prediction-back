using System.Linq.Expressions;

namespace Sales.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task SaveChangesAsync();
        Task<IEnumerable<TResult>> ExecuteStoredProcedureAsync<TResult>(string sql, params object[] parameters) where TResult : class;
    }
}
