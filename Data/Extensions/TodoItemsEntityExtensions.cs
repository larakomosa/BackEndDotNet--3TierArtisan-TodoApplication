using System;
using TodoApi.Models;
using ToDoApplicationAPI.Biz.Models;

namespace ToDoApplicationAPI.Data.Extensions
{
    /// <summary>
    /// Extenstion methods for <see cref="ClientEntity"/>.
    /// </summary>
    public static class TodoItemsEntityExtensions
    {
        /// <summary>
        /// Converts a <see cref="ClientEntity"/> to a <see cref="Client"/> model.
        /// </summary>
        public static TodoItem ToModel(this TodoItemEntity entity)
        {
            return new TodoItem(
                entity.Id,
                entity.Name,
                entity.IsComplete);
        }
    }
}
