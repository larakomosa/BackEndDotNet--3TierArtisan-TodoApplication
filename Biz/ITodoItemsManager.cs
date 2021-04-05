using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;
using ToDoApplicationAPI.Biz.Models;
using ToDoApplicationAPI.Controllers;

namespace ToDoApplicationAPI.Biz
{
    /// <summary>
    /// Biz manager for Items.
    /// </summary>
        public interface ITodoItemsManager
        {
            /// <summary>
            /// Get a todo list item by it's unique identifiers.
            /// </summary>
            /// <param name="TodoItems">The unique identifiers of the todo item to get.</param>
            /// <returns>The requested todo item.</returns>
            Task<IEnumerable<TodoItem>> Get(IEnumerable<long> clientIds);

            /// <summary>
            /// Get a set clients by their unique identifiers.
            /// </summary>
            /// <param name="TodoAll">The unique identifiers of the todo items to get.</param>
            /// <returns>The requested clients.</returns>
            Task<IEnumerable<TodoItem>> Get();

            /// <summary>
            /// Create a new todo item 
            /// </summary>
            /// <param name="info">Information required to create a new todo item.</param>
            Task<TodoItem> Create(CreateTodoItemInfo createInfo);

            /// <summary>
            /// Update a todo item.
            /// </summary>
            /// <param name="id">The unique identifier of the todo item being updated.</param>
            /// <param name="info">Information required to update a todo Item.</param>
            Task<TodoItem> Update(UpdateTodoItemInfo info);

            /// <summary>
            /// Delete a todo item.
            /// </summary>
            /// <param name="id">The unique identifier of the todo item being updated.</param>
            Task<TodoItem> Delete(long id);

        /// <summary>
        /// Search for An Item
        /// </summary>
        Task<SearchResponse<TodoItem>> Search(SearchTodoListRequestInfo info);
    };
}




