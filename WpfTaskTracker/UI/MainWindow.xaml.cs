using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfTaskTracker.Infrastructure;
using WpfTaskTracker.Models;
using WpfTaskTracker.Services;

namespace WpfTaskTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TaskService _taskService = new TaskService();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var task = new TaskItem
                {
                    Id = Guid.NewGuid().GetHashCode(),
                    Title = txtTitle.Text,
                    Deadline = dpDeadline.SelectedDate ?? DateTime.Today,
                    Priority = int.Parse(txtPriority.Text),
                    IsCompleted = false
                };

                _taskService.AddTask(task);
                lstTasks.Items.Add($"{task.Title} | {task.Deadline:d} | P{task.Priority}");
                Logger.Info("Task added.");
                MessageBox.Show("Task added successfully.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}