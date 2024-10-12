using Booking_Airline.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking_Airline.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _applicationDbContext;
    protected readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        _dbSet = _applicationDbContext.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task<bool> ExistByIdAsync(object id)
    {
        return (await _dbSet.FindAsync(id)) is not null;
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task SaveAsync()
    {
        await _applicationDbContext.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
