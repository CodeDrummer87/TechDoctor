namespace Data.Interfaces
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        T Get(int id);
        void Create (T entity);
        void Update (T entity);
        void Delete (int id);
    }
}
