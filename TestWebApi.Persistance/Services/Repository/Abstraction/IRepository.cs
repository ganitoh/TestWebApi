namespace TestWebApi.Persistance.Services.Repository.Abstraction
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        Task<TEntity> GetAsync(int entityId);
        Task<TEntity> GetNoTrackingAsync(int entityId);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task DeleteAsync(int entityId);
        Task UpdateAsync(TEntity entity);
    }
}
