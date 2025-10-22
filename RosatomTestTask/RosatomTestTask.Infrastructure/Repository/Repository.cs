using Microsoft.EntityFrameworkCore;
using RosatomTestTask.Infrastructure.Entities;

namespace RosatomTestTask.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : AbstractEntity
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public IQueryable<T> GetAll() => Context.Set<T>().AsQueryable();

        public T GetById(int id) => Context.Set<T>().Find(id);

        public void Add(T entity) => Context.Set<T>().Add(entity);

        public void Update(T entity) => Context.Entry(entity).State = EntityState.Modified;

        public void Delete(T entity) => Context.Set<T>().Remove(entity);
    }
}
