namespace AspNetCoreTodo.Models
{
public class TodoViewModel
{// Required ensures that Items is initialized during construction/initialization
        public required TodoItem[] Items { get; set; }

        // Consider using List<TodoItem> for more flexibility
        // public required List<TodoItem> Items { get; set; } = new List<TodoItem>();
    
    
}
}
