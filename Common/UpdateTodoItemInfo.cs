namespace ToDoApplicationAPI.Controllers
{
    public class UpdateTodoItemInfo
    {
        public long Id;
        public string Name;
        public bool IsComplete;

        public UpdateTodoItemInfo(long id, string name, bool isComplete)
        {
            this.Id = id;
            this.Name = name;
            this.IsComplete = isComplete;
        }
    }
}