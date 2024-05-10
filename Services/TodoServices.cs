using WebApiDemo.Models;
using Microsoft.EntityFrameworkCore;
using WebApiDemo.ViewModels;

namespace WebApiDemo.Services
{
    public class TodoService : ITodoService
    {
        private readonly ILogger<TodoService> _logger;
        private readonly WebApiDemoContext _context;

        public TodoService(ILogger<TodoService> logger, WebApiDemoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<TodoEntry>> GetAll()
        {
            return await _context.TodoEntries.ToListAsync();
        }

        public async Task<List<TodoEntry>> FilterByName(string name)
        {
            return await _context.TodoEntries
                .Where(todo => todo.Title.Contains(name))
                .ToListAsync();
        }

        public async Task<TodoEntry?> GetById(Guid id)
        {
            return await _context.TodoEntries.FindAsync(id);
        }

         public async Task<bool> AddTodo(TodoEntry entry)
        {
            if (entry == null) { return false; }
            else
            {
                await _context.TodoEntries.AddAsync(entry);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> RemoveTodo(Guid id)
        {
            var todo = await GetById(id);
            if (todo == null) { return false; }
            else
            {
                _context.TodoEntries.Remove(todo);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> UpdateTodo(Guid id, TodoEntryViewModel entry)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var todoEntry = await _context.TodoEntries.FindAsync(id);

                if (todoEntry == null)
                {
                    return false; 
                }

                todoEntry.Title = entry.Title;
                todoEntry.Description = entry.Description;
                todoEntry.DueDate = entry.DueDate;
                if (entry.Status != null) {
                    todoEntry.Status = entry.Status;
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Update Todo Failed, Message: {error}", ex);
                return false;
            }
        }
    }
}