using RosatomTestTask.Domain;
using System.Collections.ObjectModel;

namespace RosatomTestTask.Client.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Master> Masters { get; } = new();

        private Master? _selectedMaster;
        public Master? SelectedMaster
        {
            get => _selectedMaster;
            set => _selectedMaster = value;
        }

        public MainViewModel()
        {
            // Mock-данные
            var master1 = new Master
            {
                Number = "DOC-001",
                Date = DateTime.Now.AddDays(-5),
                Amount = 1500m,
                Note = "Тестовый документ",
                Details = new List<Detail>
            {
                new Detail { MasterId = 0, Name = "Сервер", Amount = 1000m },
                new Detail { MasterId = 0, Name = "Лицензия", Amount = 500m }
            }
            };

            var master2 = new Master
            {
                Number = "DOC-002",
                Date = DateTime.Now,
                Amount = 3000m,
                Note = "Ещё один документ",
                Details = new List<Detail>
            {
                new Detail { MasterId = 0, Name = "Монитор", Amount = 800m },
                new Detail { MasterId = 0, Name = "Клавиатура", Amount = 200m },
                new Detail { MasterId = 0, Name = "Мышь", Amount = 100m }
            }
            };

            Masters.Add(master1);
            Masters.Add(master2);
            SelectedMaster = master1;
        }
    }
}
