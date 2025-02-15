namespace RollAndRecord.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> All();
        Task<T> Get(int id);
        Task Save(T entity);
        Task Delete(T entity);
    }
}
