using System;
namespace ToDoApplicationAPI.Biz.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public TodoItem(string name, bool isComplete)
        {
        Name = name;
          IsComplete = isComplete;
        }

        public TodoItem(long id, string name, bool isComplete)
        {
            Id = id;
            Name = name;
            IsComplete = isComplete;
        }

        public TodoItem()
        {

        }

        internal object ToModel()
        {
            throw new NotImplementedException();
        }

    }
}
