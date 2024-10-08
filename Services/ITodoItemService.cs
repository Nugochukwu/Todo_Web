using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync(ApplicationUser user);

        Task<bool> AddItemAsync(TodoItem newItem, ApplicationUser user);
        
        Task<bool> MarkDoneAsync(Guid id, ApplicationUser user);
       // Task<bool> AddOverDueAsync(Guid id, ApplicationUser user);
        Task<bool> UpdateDueDateAsync(Guid id, DateTimeOffset newDueDate, ApplicationUser user);
        Task<List<TodoItem>> GetOverdueItemsAsync(ApplicationUser user, DateTimeOffset today);
    }
}