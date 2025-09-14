using Microsoft.AspNetCore.Mvc;
using TasksManagerMVC.Models;

namespace TasksManagerMVC.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskManager _taskManager = new();

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
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        public IActionResult Complete(int id)
        {
            _taskManager.MarkTaskComplete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _taskManager.DeleteTask(id);
            return RedirectToAction(nameof(Index));
        }
    }
}