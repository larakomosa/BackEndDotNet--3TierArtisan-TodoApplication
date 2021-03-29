using System;
namespace ToDoApplicationAPI.Biz.Models
{
    public class TodoItem
    {
        internal string name;

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public int TotalCount { get; internal set; }

        public TodoItem()
        {

        }

        public TodoItem(string name, bool isComplete)
        {
        Name = name;
            IsComplete = isComplete;
        }

        internal object ToModel()
        {
            throw new NotImplementedException();
        }
    }
}
