namespace TasksManager.Core
{
    public class TaskManager
    {
        private List<TaskItem> _tasks = new();

        public void AddTask(string description)
        {
            _tasks.Add(new TaskItem(description));
        }

        public List<TaskItem> GetTasks()
        {
            return _tasks;
        }

        public void MarkTaskComplete(int index)
        {
            if (index >= 0 && index < _tasks.Count)
            {
                _tasks[index].IsCompleted = true;
            }
        }

        public bool DeleteTask(int index)
        {
            if (index >= 0 && index < _tasks.Count)
            {
                _tasks.RemoveAt(index);
                return true;
            }
            return false;
        }
    }
}