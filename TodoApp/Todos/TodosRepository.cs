namespace TodoApp.Todos;
public class TodosRepository : ITodosRepository
{
    private readonly IStringsRepository _stringsRepository;
    public TodosRepository(IStringsRepository stringsRepository)
    {
        _stringsRepository = stringsRepository;
    }
    public List<Todo> GetAll(string filePath)
    {
        return _stringsRepository.Read<Todo>(filePath);
    }
    public Todo GetById(string filePath, string todoId)
    {
        var todos = _stringsRepository.Read<Todo>(filePath);
        foreach (var todo in todos)
        {
            if (todo.Id == todoId) return todo;
        }
        return null;
    }
    public Todo Add(string filePath, string todoText)
    {
        var allTodos = _stringsRepository.Read<Todo>(filePath);
        var newTodo = new Todo(todoText);
        allTodos.Add(newTodo);
        _stringsRepository.Write(filePath, allTodos);
        return newTodo;
    }

    public Todo Edit(string filePath, string todoId, string newText)
    {
        var allTodos = _stringsRepository.Read<Todo>(filePath);
        Todo editedTodo = null;
        foreach (var todo in allTodos)
        {
            if (todo.Id == todoId)
            {
                todo.Text = newText;
                editedTodo = todo;
            }
        }
        _stringsRepository.Write(filePath, allTodos);
        return editedTodo;
    }

    public Todo Delete(string filePath, string todoId)
    {
        var allTodos = _stringsRepository.Read<Todo>(filePath);
        foreach (var todo in allTodos)
        {
            if (todo.Id == todoId)
            {
                allTodos.Remove(todo);
                _stringsRepository.Write(filePath, allTodos);
                return todo;
            }
        }
        return null;
    }

    public void ClearAll(string filePath)
    {
        _stringsRepository.Delete(filePath);
    }
}
