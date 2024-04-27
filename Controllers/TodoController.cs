using Microsoft.AspNetCore.Mvc;
using WebApiDemo.ViewModels;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        
        private readonly ILogger<TodoController> _logger;
        private readonly WebApiDemoContext _context;

        public TodoController(ILogger<TodoController> logger, WebApiDemoContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult List()
        {
            return Ok(_context.TodoEntries.ToList());
        }

        [HttpGet("filter")]
        public ActionResult Search([FromQuery] string name)
        {
            return Ok(_context.TodoEntries
                .Where(todo => todo.Title.Contains(name))
                .ToList());
        }

        [HttpPost]
        public ActionResult Add([FromBody] TodoEntryViewModel entry)
        {
            var newTodoEntry = new TodoEntry(entry.Title, entry.Description, entry.DueDate);

            if (_context.TodoEntries.Any(existingTodo => existingTodo.Id == newTodoEntry.Id))
            {
                return Conflict("Duplicated Todo Id");
            }

            _context.TodoEntries.Add(newTodoEntry);
            return Created($"/{newTodoEntry.Id}", entry);
        }


        [HttpDelete("{todoId}")]
        public ActionResult Remove([FromRoute] Guid todoId)
        {
            TodoEntry? removeEntry = _context.TodoEntries.Find(todoId); 

            if (removeEntry == null)
            {
                return NotFound("Todo entry not found");
            }

            _context.TodoEntries.Remove(removeEntry);
            _context.SaveChanges();
            return Ok($"Removed todo with ID: {removeEntry.Id}");
        }


        [HttpPut("{todoId}")]
        public ActionResult Replace([FromRoute] Guid todoId, [FromBody] TodoEntryViewModel entry)
        {
                                                       
            TodoEntry? existingEntry = _context.TodoEntries.Find(todoId); 

            if (existingEntry == null)
            {
                    return NotFound("Todo Id not found");
            }

            existingEntry.Title = entry.Title;
            existingEntry.Description = entry.Description;
            existingEntry.DueDate = entry.DueDate;

            return Ok($"Updated todo: Title - {existingEntry.Title}, Description - {existingEntry.Description}, DueDate - {existingEntry.DueDate}");

        }
    }
}
