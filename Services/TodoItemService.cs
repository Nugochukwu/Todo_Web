using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItemAsync(TodoItem newItem, ApplicationUser user)
        {
            newItem.Id = Guid.NewGuid();
            newItem.OwnerId = user.Id;
            newItem.IsDone = false;
           // newItem.DueAt = DateTimeOffset.Now.AddDays(3);

            _context.Items.Add(newItem);
            Console.WriteLine($"Saving item: {newItem.Title}, owned by: {newItem.OwnerId}");
            var saveResult = await _context.SaveChangesAsync();
            Console.WriteLine($"Save result: {saveResult}");
            return saveResult == 1;
        }
        public async Task<TodoItem[]> GetIncompleteItemsAsync(ApplicationUser user)
        {
            return await _context.Items
                .Where(x => x.IsDone == false && x.OwnerId == user.Id)
                .ToArrayAsync();
        }
        public async Task<bool> MarkDoneAsync(Guid id, ApplicationUser user)
        {
            var item = await _context.Items
                .Where(x => x.Id == id && x.OwnerId == user.Id)
                .SingleOrDefaultAsync();
            if (item == null) return false;
            item.IsDone = true;
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; // One entity should have been updated
        }
        public async Task<List<TodoItem>> GetOverdueItemsAsync(ApplicationUser user, DateTimeOffset today)
        {
          

    // Retrieve all incomplete items for the user
    var incompleteItems = await _context.Items
        .Where(item => item.OwnerId == user.Id && !item.IsDone)
        .ToListAsync();

    // Filter overdue items in memory
    var overdueItems = incompleteItems
        .Where(item => item.DueAt < today)
        .ToList();

    return overdueItems;
        }
        public async Task<bool> UpdateDueDateAsync(Guid id, DateTimeOffset newDueDate, ApplicationUser user)
        {
            var item = await _context.Items
            .Where(x => x.Id == id && x.OwnerId == user.Id)
            .SingleOrDefaultAsync();
             if (item == null) return false;
            // Directly assign newDueDate if it's non-nullable
            item.DueAt = newDueDate;
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; // Check if exactly one entity was updated
        }
    }
}