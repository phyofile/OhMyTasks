using TasksManagerMVC.Data;

namespace TasksManagerMVC.Models
{
    public class TaskManager
    {
        private readonly ApplicationDbContext _context;

        public TaskManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddTask(string description)
        {
            var task = new TaskItem(description);
            _context.AspNetOhMyTasks.Add(task);
            _context.SaveChanges();
        }

        public List<TaskItem> GetTasks()
        {
            return _context.AspNetOhMyTasks.ToList();
        }

        public void MarkTaskComplete(int id)
        {
            var task = _context.AspNetOhMyTasks.Find(id);
            if (task != null)
            {
                task.IsCompleted = true;
                _context.SaveChanges();
            }
        }

        public bool DeleteTask(int id)
        {
            var task = _context.AspNetOhMyTasks.Find(id);
            if (task != null)
            {
                _context.AspNetOhMyTasks.Remove(task);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}