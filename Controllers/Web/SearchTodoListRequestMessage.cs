namespace ToDoApplicationAPI.Controllers
{
    public class SearchTodoListRequestMessage
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}