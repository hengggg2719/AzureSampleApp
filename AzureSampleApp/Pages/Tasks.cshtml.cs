using AzureSampleApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureSampleApp.Pages
{
    public class TasksModel : PageModel
    {
        private readonly TaskService _taskService;

        public TasksModel(TaskService taskService)
        {
            _taskService = taskService;
        }

        public IReadOnlyList<Models.TaskItem> Tasks { get; set; } = new List<Models.TaskItem>();

        [BindProperty]
        public string NewTaskTitle { get; set; } = string.Empty;

        public void OnGet()
        {
            Tasks = _taskService.GetAll();
        }

        public IActionResult OnPostAdd()
        {
            _taskService.Add(NewTaskTitle);
            return RedirectToPage();
        }

        public IActionResult OnPostToggle(int id)
        {
            _taskService.ToggleDone(id);
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            _taskService.Delete(id);
            return RedirectToPage();
        }
    }
}