namespace RosatomTestTask.Domain
{
    public class Master
    {
        public string Number { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string? Note { get; set; }
    }
}
