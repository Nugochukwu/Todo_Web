using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreTodo.Models
{
    public class TodoItem
    {
         public Guid Id { get; set; }

    // No [Required] here, since we set this programmatically
     public string OwnerId { get; set; } = "default_owner_id";
    public bool IsDone { get; set; }
   // public string? OverDueItem {get; set; }
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [Required]
    public DateTimeOffset? DueAt { get; set; }
    }
}
