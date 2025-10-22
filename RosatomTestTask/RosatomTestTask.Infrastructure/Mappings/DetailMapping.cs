using RosatomTestTask.Domain;
using RosatomTestTask.Infrastructure.Entities;

namespace RosatomTestTask.Infrastructure.Mappings
{
    public static class DetailMapping
    {
        public static Detail ToDomain(this DetailEntity entity)
        {
            return new Detail
            {
                MasterId = entity.MasterId,   // ← теперь включаем MasterId
                Name = entity.Name,
                Amount = entity.Amount
            };
        }

        public static DetailEntity ToEntity(this Detail detail)
        {
            return new DetailEntity
            {
                Name = detail.Name,
                Amount = detail.Amount,
                MasterId = detail.MasterId
            };
        }
    }
}
