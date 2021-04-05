namespace ToDoApplicationAPI.Controllers
{
    public class UpdateTodoItemMessage
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}