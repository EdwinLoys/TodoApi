using Microsoft.AspNetCore.Mvc;
using TodoApi.DTOs;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _service;

        public TasksController(TaskService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(TaskCreateDto dto)
        {
            var task = await _service.AddTask(dto);
            return Ok(task);
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _service.GetLastFive();
            return Ok(tasks);
        }

        [HttpPut("{id}/done")]
        public async Task<IActionResult> MarkDone(int id)
        {
            var ok = await _service.MarkAsDone(id);
            if (!ok) return NotFound();

            return Ok(new { status = "success" });
        }
    }
}
