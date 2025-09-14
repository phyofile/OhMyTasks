using Microsoft.AspNetCore.Mvc;
using TasksManager.Core;

namespace TasksManager.Web.Controllers
{
    public class TaskController : Controller
    {
        private static readonly TaskManager _taskManager = new();

        public IActionResult Index()
        {
            var tasks = _taskManager.GetTasks();
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string description)
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                _taskManager.AddTask(description);
                TempData["Message"] = "Task added successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Task description cannot be empty.";
            return View();
        }

        [HttpPost]
        public IActionResult Complete(int id)
        {
            _taskManager.MarkTaskComplete(id);
            TempData["Message"] = "Task marked as complete!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (_taskManager.DeleteTask(id))
            {
                TempData["Message"] = "Task deleted successfully!";
            }
            else
            {
                TempData["Error"] = "Could not delete task. Please try again.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}