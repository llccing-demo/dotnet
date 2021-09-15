using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController: Controller
    {
        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

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
    }

}