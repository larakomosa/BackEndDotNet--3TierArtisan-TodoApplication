using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
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

        async public Task<TodoItem> Create(CreateTodoItemInfo info)
        {
            var item = new TodoItem(info.Name, info.IsComplete);

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

