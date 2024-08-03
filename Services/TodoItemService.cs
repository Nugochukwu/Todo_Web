using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
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
public async Task<bool> AddItemAsync(TodoItem newItem
)
{
newItem.Id = Guid.NewGuid();
newItem.IsDone = false;
newItem.DueAt = DateTimeOffset.Now.AddDays(3);
_context.Items.Add(newItem);
var saveResult = await _context.SaveChangesAsync
();
return saveResult == 1;
}

public async Task<TodoItem[]> GetIncompleteItemsAsync()
{
/*uses the Items property of the context to access all the to-do 
items in theDbSet : */
var items = await _context.Items 
//or
//return await _context.Items

/*the Where method (a LINQ (Language Integrated Query))
is usedto filter only the items that are not complete:*/
.Where(x => x.IsDone == false)
/*tells Entity Framework Core to get all the entities that 
matched the filter and return them as an array*/
.ToArrayAsync();
return items;
}
}
}
