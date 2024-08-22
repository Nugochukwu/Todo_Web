using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreTodo.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        public bool IsDone { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        public DateTimeOffset? DueAt { get; set; }
    }
}
