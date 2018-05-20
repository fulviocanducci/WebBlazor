namespace WebBlazor.Models
{   
    public class Todo
    {
        public Todo()
        {
        }

        public Todo(string title)
        {
            Id = 0;
            Title = title;
        }

        public Todo(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
    }
}
