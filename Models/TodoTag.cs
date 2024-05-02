using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models;

public class TodoTag
{
    [Key]

    public Guid Id { get; set; }
    [Required]
    [Length(1,100)]
    [RegularExpression("^\\w+$", MatchTimeoutInMilliseconds = 1000)]

    public string Name { get; set; } = string.Empty;

    public List<TodoEntry> TaggedEntries { get; } = [];

}
