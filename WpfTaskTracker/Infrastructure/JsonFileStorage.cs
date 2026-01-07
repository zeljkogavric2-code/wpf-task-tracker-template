using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WpfTaskTracker.Models;

namespace WpfTaskTracker.Infrastructure
{
    public class JsonFileStorage
    {
        private const string FileName = "tasks.json";

        public List<TaskItem> Load()
        {
            if (!File.Exists(FileName))
            {
                Logger.Info("tasks.json not found. Starting with empty list.");
                return new List<TaskItem>();
            }

            try
            {
                var json = File.ReadAllText(FileName);
                Logger.Info("Tasks loaded from JSON file.");
                return JsonSerializer.Deserialize<List<TaskItem>>(json);
            }
            catch
            {
                Logger.Error("Failed to load tasks from JSON.");
                return new List<TaskItem>();
            }
        }

        public void Save(IEnumerable<TaskItem> tasks)
        {
            try
            {
                var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(FileName, json);
                Logger.Info("Tasks saved to JSON file.");
            }
            catch
            {
                Logger.Error("Failed to save tasks to JSON.");
            }
        }
    }
}
