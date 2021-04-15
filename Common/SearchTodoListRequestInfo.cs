namespace ToDoApplicationAPI.Controllers
{
    public class SearchTodoListRequestInfo
    {
       public long id;
        public string name;
        public bool? isComplete;

        public SearchTodoListRequestInfo(long id, string name, bool? isComplete)
        {
            this.id = id;
            this.name = name;
            this.isComplete = isComplete;
        }
    }
}