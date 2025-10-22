using Microsoft.EntityFrameworkCore;
using RosatomTestTask.Infrastructure.Entities;
using RosatomTestTask.Infrastructure.Repository;

namespace RosatomTestTask.Infrastructure.UOW
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly RosatomTestTaskDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public IRepository<MasterEntity> MasterEntities => GetRepository<MasterEntity>();
        public IRepository<DetailEntity> DetailEntities => GetRepository<DetailEntity>();

        public UnitOfWorks(RosatomTestTaskDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        private IRepository<T> GetRepository<T>() where T : AbstractEntity
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)_repositories[typeof(T)];
            }

            var repository = new Repository<T>(_context);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        public void Dispose()
        { }
    }
}
