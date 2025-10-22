using RosatomTestTask.Infrastructure.Entities;

namespace RosatomTestTask.Infrastructure.Repository
{
    public interface IRepository<T> where T : AbstractEntity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
