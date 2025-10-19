using RosatomTestTask.Domain;
using RosatomTestTask.Infrastructure.Entities;

namespace RosatomTestTask.Infrastructure.Mappings
{
    public static class DetailMapping
    {
        public static DetailEntity ToEntity(this Detail detail, int masterId)
        {
            return new DetailEntity
            {
                Name = detail.Name,
                Amount = detail.Amount,
                MasterId = masterId
            };
        }

        public static Detail ToDomain(this DetailEntity entity)
        {
            return new Detail
            {
                Name = entity.Name,
                Amount = entity.Amount
            };
        }
    }
}
