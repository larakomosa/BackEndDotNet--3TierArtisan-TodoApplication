using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApplicationAPI.Biz;
using ToDoApplicationAPI.Biz.Models;

namespace ToDoApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemsManager _manager;

        public TodoItemsController(ITodoItemsManager manager)
        {
            _manager = manager;
        }

        // GET: api/TodoItems
        [HttpGet]
         public async Task<ActionResult<TodoItem>> GetTodoItem()
        {
            var todoItem = await _manager.Get();

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _manager.Get(new long[] { id });

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        // GET: api/TodoItems/Count
        [HttpGet]
        public async Task<ActionResult<TodoItem>> GetCountOfRestaurants()
        {
            var todoItem = await _manager.Get();

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        [HttpPost]
        public async Task<ActionResult>PostTodoItem([FromBody] CreateTodoItemMessage request)
        {

            var createInfo = new CreateTodoItemInfo(request.Name, request.IsComplete);

            await _manager.Create(createInfo);

            return new OkObjectResult(createInfo);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTodoItem([FromRoute] long id, [FromBody] UpdateTodoItemMessage request)
        {
            var info = new UpdateTodoItemInfo(request.Name, request.IsComplete);

            await _manager.Update(id, info);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] long id)
        {
            await _manager.Delete(id);

            return new OkResult();
        }

    }

}
