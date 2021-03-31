using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artisan.Core.Exceptions;
using Artisan.Service.Core.Web;
using ToDoApplicationAPI.Biz.Models;
using ToDoApplicationAPI.Controllers.Contracts;
using ToDoApplicationAPI.Controllers.Extensions;

namespace ToDoApplicationAPI.Controllers.Builders
{
    /// <summary>
    /// Converts <see cref="Account"/> models to <see cref="AccountResponse"/>.
    /// </summary>
    internal class TodoItemResponseBuilder : IMessageBuilder<TodoItem, TodoItemResponse>
    {
        /// <inheritdoc/>
        public async Task<IEnumerable<TodoItemResponse>> Build(IMessageBuilderContext<TodoItem, TodoItemResponse> context)
        {
            var results = new List<TodoItemResponse>();

            foreach (var obj in context.Items)
            {
                var response = obj.ToResponse();

                results.Add(response);
            }

            return results;
        }
    }
}
