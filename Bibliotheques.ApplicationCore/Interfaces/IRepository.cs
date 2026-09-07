namespace Bibliotheques.ApplicationCore.Interfaces;
public interface IRepository<T> where T : class {
    Task<T?> GetByIdAsync(object id);
    Task<List<T>> GetAllAsync();
    void Add(T entity);
    void Remove(T entity);
    Task SaveChangesAsync();
}
