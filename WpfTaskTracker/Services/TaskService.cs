using System;
using System.Collections.Generic;
using WpfTaskTracker.Infrastructure;
using WpfTaskTracker.Models;

namespace WpfTaskTracker.Services
{
    public class TaskService
    {
        private readonly JsonFileStorage _storage = new JsonFileStorage();
        private readonly List<TaskItem> _tasks;

        public TaskService()
        {
            Logger.Info("TaskService initialized.");
            _tasks = _storage.Load();
        }

        public IEnumerable<TaskItem> GetAll()
        {
            Logger.Info("Fetching all tasks.");
            return _tasks;
        }

        public void Add(TaskItem task)
        {
            Logger.Info($"Attempting to add task: {task?.Title}");

            if (string.IsNullOrWhiteSpace(task.Title))
            {
                Logger.Error("Task title validation failed.");
                throw new InvalidOperationException("Title is required.");
            }

            if (task.Deadline < DateTime.Today)
            {
                Logger.Error("Task deadline validation failed.");
                throw new InvalidOperationException("Deadline cannot be in the past.");
            }

            if (task.Priority < 1 || task.Priority > 5)
            {
                Logger.Error("Task priority validation failed.");
                throw new InvalidOperationException("Priority must be 1–5.");
            }

            _tasks.Add(task);
            Logger.Info("Task added to in-memory list.");

            _storage.Save(_tasks);
        }

        public void SaveAll()
        {
            Logger.Info("Manual save requested.");
            _storage.Save(_tasks);
        }
    }
}
