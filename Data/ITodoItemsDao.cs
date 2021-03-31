using System;
using System.Threading.Tasks;
using ToDoApplicationAPI.Biz;
using ToDoApplicationAPI.Biz.Models;
using ToDoApplicationAPI.Controllers;

namespace ToDoApplicationAPI.Data
{
    internal interface ITodoItemsDao
    {
        Task<TodoItem> Create(CreateTodoItemInfo createInfo);
        Task<TodoItem> Update(long id, UpdateTodoItemInfo info);
        Task<TodoItem> Delete(long id);
        Task<SearchResponse<TodoItem>> Search(SearchTodoListRequestInfo info);
    }
}