using System.ComponentModel.DataAnnotations;

namespace TodoCQRS.Domain.Entities;

public class Todo
{
    public Todo(string title, string description)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        IsCompleted = false;
    }

    public Guid Id { get; set; }

    [Required] public string Title { get; set; }

    [Required] public string Description { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}