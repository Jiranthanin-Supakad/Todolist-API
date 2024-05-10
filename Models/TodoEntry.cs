using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models;

public class TodoEntry
{
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();


    [StringLength(100, MinimumLength = 1)]
    [RegularExpression("[\\w\\s]+")]
    public string Title { get; set; } = string.Empty;


    [RegularExpression("[\\w\\s]+")]
    public string? Description { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime? DueDate { get; set; }

    public string? Status { get; set; }

    //public List<TodoTag> Tags { get; } = [];

    //public Users Owner { get; set;} = null;

    public TodoEntry() { }

    public TodoEntry(string title, string? description = null, DateTime? dueDate = null, string status = "Todo")
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        CreateDate = DateTime.Now;
        UpdateDate = DateTime.Now;
        DueDate = dueDate;
        Status = status;
    }

    public TodoEntry(TodoEntry entry)
    {
        Id = entry.Id;
        Title = entry.Title;
        Description = entry.Description;
        CreateDate = entry.CreateDate;
        UpdateDate = entry.UpdateDate;
        DueDate = entry.DueDate;
        Status = entry.Status;
    }

    public override string ToString()
    {
        string dueDateString = DueDate.HasValue ? DueDate.Value.ToString("yyyy-MM-dd HH:mm") : "N/A";
        return $"[{Id}] {Title} {Description} {dueDateString}";
    }

}
