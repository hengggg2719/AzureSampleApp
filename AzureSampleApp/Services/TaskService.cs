using AzureSampleApp.Models;

namespace AzureSampleApp.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new();
        private int _nextId = 1;
        private readonly object _lock = new();

        public IReadOnlyList<TaskItem> GetAll()
        {
            lock (_lock)
            {
                return _tasks.OrderByDescending(t => t.CreatedAt).ToList();
            }
        }

        public void Add(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) return;
            lock (_lock)
            {
                _tasks.Add(new TaskItem { Id = _nextId++, Title = title.Trim() });
            }
        }

        public void ToggleDone(int id)
        {
            lock (_lock)
            {
                var task = _tasks.FirstOrDefault(t => t.Id == id);
                if (task != null) task.IsDone = !task.IsDone;
            }
        }

        public void Delete(int id)
        {
            lock (_lock)
            {
                _tasks.RemoveAll(t => t.Id == id);
            }
        }
    }
}