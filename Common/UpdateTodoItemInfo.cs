namespace ToDoApplicationAPI.Controllers
{
    public class UpdateTodoItemInfo
    {
        public string Name;
        public bool IsComplete;

        public UpdateTodoItemInfo(string name, bool isComplete)
        {
            this.Name = name;
            this.IsComplete = isComplete;
        }
    }
}