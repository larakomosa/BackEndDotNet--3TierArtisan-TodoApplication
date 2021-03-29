namespace ToDoApplicationAPI.Biz
{
    public class SearchResult<T>
    {
        private object p;
        private int count;

        public SearchResult(object p, int count)
        {
            this.p = p;
            this.count = count;
        }
    }
}