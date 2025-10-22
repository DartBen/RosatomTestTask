namespace RosatomTestTask.Infrastructure.Entities
{
    public class MasterEntity : AbstractEntity
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty; // номер документа
        public DateTime Date { get; set; }                 // дата
        public decimal Amount { get; set; }                // сумма (итоговая, можно считать из Detail, но оставим как поле)
        public string? Note { get; set; }                  // примечание
        public List<DetailEntity> Details { get; set; } = new();
    }
}
