using Bibliotheques.ApplicationCore.Interfaces;
using Bibliotheques.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Bibliotheques.Infrastructure.Repositories;
public class Repository<T> : IRepository<T> where T:class {
    protected readonly BibliothequeDbContext Context;
    public Repository(BibliothequeDbContext context)=>Context=context;
    public virtual Task<T?> GetByIdAsync(object id)=>Context.Set<T>().FindAsync(id).AsTask();
    public virtual Task<List<T>> GetAllAsync()=>Context.Set<T>().ToListAsync();
    public void Add(T entity)=>Context.Set<T>().Add(entity);
    public void Remove(T entity)=>Context.Set<T>().Remove(entity);
    public Task SaveChangesAsync()=>Context.SaveChangesAsync();
}
