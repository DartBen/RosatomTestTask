namespace RosatomTestTask.Infrastructure.Entities
{
    public class DetailEntity : AbstractEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;   // наименование
        public decimal Amount { get; set; }                // сумма по строке

        // Внешний ключ
        public int MasterId { get; set; }
        public MasterEntity Master { get; set; } = null!;
    }
}
