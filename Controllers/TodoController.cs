using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Services;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace AspNetCoreTodo.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<TodoController> _logger;

        public TodoController(
            ITodoItemService todoItemService,
            UserManager<ApplicationUser> userManager,ILogger<TodoController> logger)
        {
            _logger = logger;
            _todoItemService = todoItemService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("This is the home page");
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Challenge();
            }
            var today = DateTimeOffset.Now;
            var todoItems = await _todoItemService.GetIncompleteItemsAsync(currentUser);
            var overdueItems = await _todoItemService.GetOverdueItemsAsync(currentUser, today);
            var model = new TodoViewModel()
            {
                Items = todoItems,
                OverdueItems = overdueItems
            };

            return View(model);
        }
       
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.AddItemAsync(newItem, currentUser);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }

            return RedirectToAction("Index");
        }
        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.MarkDoneAsync(id, currentUser);
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }

            return RedirectToAction("Index");
        }
       
         [ValidateAntiForgeryToken]
   public async Task<IActionResult> EditDueDate(Guid id, DateTime dueDate)
{
    if (id == Guid.Empty)
    {
        return RedirectToAction("Index");
    }

    var currentUser = await _userManager.GetUserAsync(User);
    if (currentUser == null)
    {
        return RedirectToAction("Index");
    }

    var successful = await _todoItemService.UpdateDueDateAsync(id, dueDate, currentUser);
    if (!successful)
    {
        return BadRequest("DueDate already Set(Could not update duedate)");
    }

    return RedirectToAction("Index");
}

    }
}