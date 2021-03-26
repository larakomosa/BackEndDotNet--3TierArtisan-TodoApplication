namespace ToDoApplicationAPI.Controllers
{
    public class CreateTodoItemInfo
    {
        public string Name;
        public bool IsComplete;

        public CreateTodoItemInfo(string name, bool isComplete)
        {
            this.Name = name;
            this.IsComplete = isComplete;
        }
    }
}

