using System;
using System.Threading.Tasks;
using ToDoApplicationAPI.Biz.Models;
using ToDoApplicationAPI.Controllers;

namespace ToDoApplicationAPI.Data
{
    internal interface ITodoItemsDao
    {
        Task<TodoItem> Create(CreateTodoItemInfo info);
        Task<TodoItem> Update(long id, UpdateTodoItemInfo info);
        Task<TodoItem> Delete(long id);
    }
}