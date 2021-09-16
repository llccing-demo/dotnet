using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using System;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreTodo.Controllers
{
    [Authorize]
    public class TodoController: Controller
    {
        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        // 返回首页
        public async Task<IActionResult> Index()
        {
            // go to items from database
            var items = await _todoItemService.GetIncompleteItemAsync();

            // Put items into a model
            var model = new TodoViewModel()
            {
                Items = items
            };

            // Pass the view to a model and render
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Could not add item");
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

            var successful = await _todoItemService.MarkDoneAsync(id);
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }

            //此处会被重定向到 Todo/Index，而不是整个网站的 Index
            return RedirectToAction("Index");

        }
    }

}