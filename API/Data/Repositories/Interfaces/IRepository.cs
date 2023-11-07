namespace API.Data.Repositories.Interfaces
{
    // TEntity is generic type
    // Repository pattern is a design pattern that abstracts the data access logic from rest of the application
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}