using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfTaskTracker.Models;
using WpfTaskTracker.Services;
using WpfTaskTracker.Infrastructure;

namespace WpfTaskTracker.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly TaskService _service = new TaskService();

        public ObservableCollection<TaskItem> Tasks { get; }

        public string Title { get; set; }
        public DateTime Deadline { get; set; } = DateTime.Today;
        public int Priority { get; set; }

        public ICommand AddTaskCommand { get; }

        public MainViewModel()
        {
            Tasks = new ObservableCollection<TaskItem>(_service.GetAll());
            AddTaskCommand = new RelayCommand(AddTask);
        }

        private void AddTask()
        {
            var task = new TaskItem
            {
                Title = Title,
                Deadline = Deadline,
                Priority = Priority
            };

            _service.Add(task);
            Tasks.Add(task);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
