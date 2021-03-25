using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;
using ToDoApplicationAPI.Biz.Models;

namespace ToDoApplicationAPI.Biz
{
    /// <summary>
    /// Biz manager for Items.
    /// </summary>
        public interface ITodoItemsManager
        {
            /// <summary>
            /// Get a set clients by their unique identifiers.
            /// </summary>
            /// <param name="TodoItems">The unique identifiers of the clients to get.</param>
            /// <returns>The requested clients.</returns>
            Task<IEnumerable<TodoItem>> Get(IEnumerable<long> clientIds);

        /// <summary>
        /// Get a set clients by their unique identifiers.
        /// </summary>
        /// <param name="TodoAll">The unique identifiers of the clients to get.</param>
        /// <returns>The requested clients.</returns>
        Task<IEnumerable<TodoItem>> Get();

        ///// <summary>
        ///// Get a client by its unique identifier.
        ///// </summary>
        ///// <param name="clientId">The unique identifier of the client to get.</param>
        ///// <returns>The requested client.</returns>
        //Task<TodoItemEntity> Get(int Id);

        ///// <summary>
        ///// Create a new client.
        ///// </summary>
        ///// <param name="info">Information required to create a new client.</param>
        //Task<TodoItemEntity> Create(? info);

        ///// <summary>
        ///// Update a client.
        ///// </summary>
        ///// <param name="clientId">The unique identifier of the client being updated.</param>
        ///// <param name="info">Information required to update a client.</param>
        //Task<TodoItemEntity> Update(int, ? info);
    }
    }




