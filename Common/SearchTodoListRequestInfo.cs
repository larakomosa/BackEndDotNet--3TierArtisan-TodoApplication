namespace ToDoApplicationAPI.Controllers
{
    public class SearchTodoListRequestInfo
    {
       public object id;
        public object name;
        public object isComplete;

        public SearchTodoListRequestInfo(object id, object name, object isComplete)
        {
            this.id = id;
            this.name = name;
            this.isComplete = isComplete;
        }
    }
}