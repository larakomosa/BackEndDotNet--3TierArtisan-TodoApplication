namespace ToDoApplicationAPI.Controllers
{
    public class CreateTodoItemMessage
    {
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}