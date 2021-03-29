using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using ToDoApplicationAPI.Biz;
using ToDoApplicationAPI.Biz.Models;
using ToDoApplicationAPI.Controllers;

namespace ToDoApplicationAPI.Data
{
    public class TodoItemsDao: ITodoItemsDao
    {
        private readonly TodoContext todoContext;

        public TodoItemsDao(TodoContext todoContext)
        {
            this.todoContext = todoContext;
        }

        async public Task<TodoItem> Create(CreateTodoItemInfo createInfo)
        {
            var item = new TodoItem(createInfo.Name, createInfo.IsComplete);

            todoContext.TodoItems.Add(item);
            await todoContext.SaveChangesAsync();

            return item;

        }

        async public Task<TodoItem> Update(long id, UpdateTodoItemInfo info)

        {
            var change = await todoContext.TodoItems
                .FirstAsync(i => i.Id == id);

            change.Name = info.Name;
            change.IsComplete = info.IsComplete;

            await todoContext.SaveChangesAsync();

            return change;

        }
        async public Task<TodoItem> Delete(long id)
        {
            var item = await todoContext.TodoItems.FindAsync(id);
            todoContext.TodoItems.Remove(item);

            await todoContext.SaveChangesAsync();

            return item;
        }


    }
    }

