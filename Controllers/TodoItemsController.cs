using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApplicationAPI.Biz;
using ToDoApplicationAPI.Biz.Models;
using Artisan.Core.Extensions;
using Artisan.Service.Core.Web;
using ToDoApplicationAPI.Controllers.Contracts;

namespace ToDoApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemsManager _manager;
        private readonly IMessageFactory _factory;


        public TodoItemsController(ITodoItemsManager manager, IMessageFactory factory)
        {
            _manager = manager;
            _factory = factory;

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

        [HttpPost]
        public async Task<ActionResult>PostTodoItem([FromBody] CreateTodoItemMessage request)
        {

            var createInfo = new CreateTodoItemInfo(request.Name, request.IsComplete);

            await _manager.Create(createInfo);

            return new OkObjectResult(createInfo);

        }

        [HttpPut()]
        public async Task<ActionResult> UpdateTodoItem([FromBody] UpdateTodoItemMessage request)
        {
            var info = new UpdateTodoItemInfo(request.Id, request.Name, request.IsComplete);

            await _manager.Update(info);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] long id)
        {
            await _manager.Delete(id);

            return new OkResult();
        }

        [HttpGet("search")]
        public async Task<SearchResponse<TodoItemResponse>> SearchTodoList([FromQuery] long id, [FromQuery] string name, [FromQuery] bool? isComplete)

        {
            var info = new SearchTodoListRequestInfo(id, name, isComplete);

            var results = await _manager.Search(info);

            var responses = await _factory.Create<TodoItem, TodoItemResponse>(results.Data);

            return new SearchResponse<TodoItemResponse>(responses, results.TotalCount);
        }


    }

}
