namespace Booking_Airline.Infrastructure.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(object id);
    Task<bool> ExistByIdAsync(object id);
    Task AddAsync(T entity);
    void Remove(T entity);
    void Update(T entity);
    Task SaveAsync();
}
