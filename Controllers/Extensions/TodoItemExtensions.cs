using ToDoApplicationAPI.Biz.Models;
using ToDoApplicationAPI.Controllers.Contracts;

namespace ToDoApplicationAPI.Controllers.Extensions
{
    /// <summary>
    /// Extenstion methods for <see cref="Account"/>.
    /// </summary>
    public static class TodoItemExtensions
    {
        /// <summary>
        /// Converts a <see cref="Account"/> to a <see cref="AccountResponse"/>.
        /// </summary>
        public static TodoItemResponse ToResponse(this TodoItem model)
        {
            return new TodoItemResponse(model.Id, model.Name, model.IsComplete);
        }
    }
}
