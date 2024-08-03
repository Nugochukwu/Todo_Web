using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Services;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Controllers
{
 //   [Authorize]
public class TodoController : Controller
{
    private readonly ITodoItemService _todoItemService;
public TodoController(
            ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

public async Task<IActionResult> Index()
{
var items = await _todoItemService.GetIncompleteItemsAsync();
var model = new TodoViewModel()
{
Items = items
};
return View(model);
// Put items into a model
// Pass the view to a model and render
}
[ValidateAntiForgeryToken]
//boop
public async Task<IActionResult> AddItem(TodoItem newItem)
{
if (!ModelState.IsValid)
{
return RedirectToAction("Index");
}
var successful = await _todoItemService.AddItemAsync(newItem);
if (!successful)
{
return BadRequest("Could not add item.");
}
return RedirectToAction("Index");
}
}
}