namespace TodoApp.Todos
{
    public interface ITodosRepository
    {
        Todo Add(string filePath, string todoText);
        void ClearAll(string filePath);
        Todo Delete(string filePath, string todoId);
        Todo Edit(string filePath, string todoId, string newText);
        List<Todo> GetAll(string filePath);
        Todo GetById(string filePath, string todoId);
    }
}