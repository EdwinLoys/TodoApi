using TodoApi.Data;
using TodoApi.Models;
using TodoApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Services
{
    public class TaskService
    {
        private readonly AppDbContext _db;

        public TaskService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<TaskItem> AddTask(TaskCreateDto dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description
            };

            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();

            return task;
        }

        public async Task<List<TaskItem>> GetLastFive()
        {
            return await _db.Tasks
                .Where(t => !t.Completed)
                .OrderByDescending(t => t.CreatedAt)
                .Take(5)
                .ToListAsync();
        }

        public async Task<bool> MarkAsDone(int id)
        {
            var task = await _db.Tasks.FindAsync(id);
            if (task == null) return false;

            task.Completed = true;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
