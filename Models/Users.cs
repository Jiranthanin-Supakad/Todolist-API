using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models;

public class Users
{
    [Key]

    public Guid UserId { get; set; }

    [RegularExpression("^\\w+")]

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public List<TodoEntry> TaggedEntries { get; } = [];

}
