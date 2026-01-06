using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTaskTracker.Models;

namespace WpfTaskTracker.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new List<TaskItem>();

        public void AddTask(TaskItem task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
                throw new InvalidOperationException("Task title is required.");

            if (task.Deadline < DateTime.Today)
                throw new InvalidOperationException("Deadline cannot be in the past.");

            if (task.Priority < 1 || task.Priority > 5)
                throw new InvalidOperationException("Priority must be between 1 and 5.");

            _tasks.Add(task);
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return _tasks;
        }
    }
}
