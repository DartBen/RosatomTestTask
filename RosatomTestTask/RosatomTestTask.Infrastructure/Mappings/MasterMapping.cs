using RosatomTestTask.Domain;
using RosatomTestTask.Infrastructure.Entities;

namespace RosatomTestTask.Infrastructure.Mappings
{
    public static class MasterMapping
    {
        public static MasterEntity ToEntity(this Master master)
        {
            return new MasterEntity
            {
                Number = master.Number,
                Date = master.Date,
                Amount = master.Amount,
                Note = master.Note
            };
        }

        public static Master ToDomain(this MasterEntity entity)
        {
            return new Master
            {
                Number = entity.Number,
                Date = entity.Date,
                Amount = entity.Amount,
                Note = entity.Note
            };
        }
    }
}
