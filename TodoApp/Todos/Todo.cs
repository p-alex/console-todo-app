namespace TodoApp.Todos
{
    public class Todo
    {
        public string Id { get; init; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; init; }
        public Todo(string text)
        {
            Id = Guid.NewGuid().ToString();
            Text = text;
            CreatedAt = DateTime.Now;
        }
    }
}
