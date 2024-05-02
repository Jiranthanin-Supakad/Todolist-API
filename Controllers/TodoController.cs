using Microsoft.AspNetCore.Mvc;
using WebApiDemo.ViewModels;
using WebApiDemo.Models;
using WebApiDemo.Services;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        
        private readonly ILogger<TodoController> _logger;
        private readonly WebApiDemoContext? _context;
        private readonly ITodoService _todoService;

        // private readonly string? userId;

        public TodoController(ILogger<TodoController> logger, WebApiDemoContext context, ITodoService todoService)
        {
            _logger = logger;
            // _context = context;
            _todoService = todoService;
        }
            
        [HttpGet]
        public async Task<ActionResult> List()
        {
            return Ok(await _todoService.GetAll());
        }

        [HttpGet("filter")]
        public async Task<ActionResult> Search([FromQuery] string name)
        {
            return Ok(await _todoService.FilterByName(name));
        }

        // [HttpPost]
        // public async Task<ActionResult> Add([FromBody] TodoEntryViewModel entry)
        // {
        //     var newTodoEntry = new TodoEntry(entry.Title, entry.Description, entry.DueDate);

        //     if (_todoService.TodoEntries.Any(existingTodo => existingTodo.Id == newTodoEntry.Id))
        //     {
        //         return Conflict("Duplicated Todo Id");
        //     }

        //     _todoService.TodoEntries.Add(newTodoEntry);
        //     _todoService.SaveChanges();
        //     return Created(await $"/{newTodoEntry.Id}", entry);
        // }


        // [HttpDelete("{todoId}")]
        // public async Task<ActionResult> Remove([FromRoute] Guid todoId)
        // {
        //     TodoEntry? removeEntry = _todoService.TodoEntries.Find(todoId); 

        //     if (removeEntry == null)
        //     {
        //         return NotFound("Todo entry not found");
        //     }

        //     _todoService.TodoEntries.Remove(removeEntry);
        //     _todoService.SaveChanges();
        //     return Ok(await $"Removed todo with ID: {removeEntry.Id}");
        // }


        // [HttpPut("{todoId}")]
        // public async Task<ActionResult> Replace([FromRoute] Guid todoId, [FromBody] TodoEntryViewModel entry)
        // {
                                                       
        //     TodoEntry? existingEntry = _todoService.UpdateTodo(todoId); 

        //     if (existingEntry == null)
        //     {
        //             return NotFound("Todo Id not found");
        //     }

        //     existingEntry.Title = entry.Title;
        //     existingEntry.Description = entry.Description;
        //     existingEntry.DueDate = entry.DueDate;

        //     return Ok(await $"Updated todo: Title - {existingEntry.Title}, Description - {existingEntry.Description}, DueDate - {existingEntry.DueDate}");

        // }
    }
}
