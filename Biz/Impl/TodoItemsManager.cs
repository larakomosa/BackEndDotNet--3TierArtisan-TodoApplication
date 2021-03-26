using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplicationAPI.Data;
using TodoApi.Models;
using ToDoApplicationAPI.Biz.Models;
using ToDoApplicationAPI.Controllers;

namespace ToDoApplicationAPI.Biz
{
    internal class TodoItemsManager : ITodoItemsManager
    {
        private readonly TodoContext todoContext;
        private readonly ITodoItemsDao todoItemsDao;

        public TodoItemsManager(TodoContext todoContext, ITodoItemsDao todoItemsDao)
        {
            this.todoContext = todoContext;
            this.todoItemsDao = todoItemsDao;
        }

        public async Task<IEnumerable<TodoItem>> Get(IEnumerable<long> TodoIds)
        {

            return await todoContext.TodoItems
                .Where(item => TodoIds.Contains(item.Id))
                .Select(item => new TodoItem { Id = item.Id, Name = item.Name, IsComplete = item.IsComplete })
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> Get()
        {

            return await todoContext.TodoItems
                .Select(item => new TodoItem { Id = item.Id, Name = item.Name, IsComplete = item.IsComplete })
                .ToListAsync();
        }

        public async Task<TodoItem> Create(CreateTodoItemInfo info)
        {

            return await todoItemsDao.Create(info);
        }

        public async Task<TodoItem> Update (long id, UpdateTodoItemInfo info)
        {
            return await todoItemsDao.Update(id, info);
}

        public async Task<TodoItem> Delete(long id)
        {
            return await todoItemsDao.Delete(id);
        }

    }

    }

    
    
