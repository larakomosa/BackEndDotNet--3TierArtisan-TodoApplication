using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplicationAPI.Data;
using TodoApi.Models;
using ToDoApplicationAPI.Biz.Models;
using ToDoApplicationAPI.Controllers;
using Artisan.Core.Extensions;
using Artisan.Core.Exceptions;

namespace ToDoApplicationAPI.Biz
{
    internal class TodoItemsManager : ITodoItemsManager
    {
        private readonly TodoContext todoContext;
        private readonly ITodoItemsDao todoItemsDao;

        public TodoItemsManager(TodoContext todoContext, ITodoItemsDao todoItemsDao)
        {
            Verify.That(todoContext, nameof(todoContext)).IsNotNull();
            Verify.That(todoItemsDao, nameof(todoItemsDao)).IsNotNull();

            this.todoContext = todoContext;
            this.todoItemsDao = todoItemsDao;
        }

        public async Task<IEnumerable<TodoItem>> Get(IEnumerable<long> TodoIds)
        {
            Verify.That(TodoIds, nameof(TodoIds)).IsNotNull();
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

        public async Task<TodoItem> Create(CreateTodoItemInfo createInfo)
        {
            Verify.That(createInfo, nameof(createInfo)).IsNotNull();
   

            return await todoItemsDao.Create(createInfo);
        }

        public async Task<SearchResponse<TodoItem>> Search(SearchTodoListRequestInfo info)
        {
            Verify.That(info, nameof(info)).IsNotNull();

            return await todoItemsDao.Search(info);
        }


        public async Task<TodoItem> Update (UpdateTodoItemInfo info)
        {

            Verify.That(info, nameof(info)).IsNotNull();

            return await todoItemsDao.Update(info);
        }

        public async Task<TodoItem> Delete(long id)
        {
            Verify.That(id, nameof(id)).IsNotNull();

            return await todoItemsDao.Delete(id);
        }
    }

    }

    
    
