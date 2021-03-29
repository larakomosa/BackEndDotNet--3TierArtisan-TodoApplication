namespace ToDoApplicationAPI.Controllers
{
   public class SearchTodoListRequestInfo
    {
        public long Id;
        public string Name;
        public bool IsComplete;

        public SearchTodoListRequestInfo(long id, string name, bool isComplete)
        {
            this.Id = id;
            this.Name = name;
            this.IsComplete = isComplete;
        }
    }
}