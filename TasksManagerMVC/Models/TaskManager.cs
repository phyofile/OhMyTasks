namespace TasksManagerMVC.Models
{
    public class TaskManager
    {
        private static List<TaskItem> _tasks = new();
        private static int _nextId = 1;

        public void AddTask(string description)
        {
            var task = new TaskItem(description) { Id = _nextId++ };
            _tasks.Add(task);
        }

        public List<TaskItem> GetTasks()
        {
            return _tasks;
        }

        public void MarkTaskComplete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
            }
        }

        public bool DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
                return true;
            }
            return false;
        }
    }
}