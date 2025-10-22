using RosatomTestTask.Infrastructure.Entities;
using RosatomTestTask.Infrastructure.Repository;

namespace RosatomTestTask.Infrastructure.UOW
{
    public interface IUnitOfWorks : IDisposable
    {
        IRepository<MasterEntity> MasterEntities { get; }
        IRepository<DetailEntity> DetailEntities { get; }
        Task<int> SaveChangesAsync();
    }
}
