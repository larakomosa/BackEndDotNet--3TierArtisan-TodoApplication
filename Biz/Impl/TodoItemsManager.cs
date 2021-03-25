using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplicationAPI.Data;
using TodoApi.Models;
using ToDoApplicationAPI.Biz.Models;

namespace ToDoApplicationAPI.Biz
{
    internal class TodoItemsManager : ITodoItemsManager
    {
        private readonly TodoContext todoContext;

        public TodoItemsManager(TodoContext todoContext)
        {
            this.todoContext = todoContext;
        }
        public async Task<IEnumerable<TodoItem>> Get()
        {

            return await todoContext.TodoItems
                .Select(item => new TodoItem { Id = item.Id, Name = item.Name, IsComplete = item.IsComplete })
                .ToListAsync();
        }
        public async Task<IEnumerable<TodoItem>> Get(IEnumerable<long> TodoIds)
        {

            return await todoContext.TodoItems
                .Where(item => TodoIds.Contains(item.Id))
                .Select(item => new TodoItem { Id = item.Id, Name = item.Name, IsComplete = item.IsComplete })
                .ToListAsync();
        }

    }
}
    
    
