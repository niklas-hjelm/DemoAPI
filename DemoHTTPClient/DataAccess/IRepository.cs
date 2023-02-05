namespace DemoHTTPClient.DataAccess;

public interface IRepository<T> where T : class
{
    Task AddAsync(T item);
    Task<T> GetAsync(object id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllWithDifficultyAsync(string difficulty);
    Task DeleteAsync(object id);
    Task UpdateAsync(object id, T item);
}