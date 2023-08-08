using TodoApp.Todos;

public class TodoApplication
{
    private readonly ITodosUserInteraction _todosUserInteraction;
    private readonly ITodosRepository _todosRepository;
    private string _fileName;
    private string _fileType;
    private string _filePath;

    public TodoApplication(ITodosUserInteraction todosUserInteraction, ITodosRepository todosRepository, string fileName, string fileType)
    {
        _todosUserInteraction = todosUserInteraction;
        _todosRepository = todosRepository;
        _fileName = fileName;
        _fileType = fileType;
        _filePath = $"{_fileName}.{_fileType}";
    }

    public void Run()
    {
        _todosUserInteraction.PrintMessage("Welcome!");
        _todosUserInteraction.PrintMessage("");
        var allTodos = _todosRepository.GetAll(_filePath);
        if (allTodos.Count != 0)
        {
            _todosUserInteraction.PrintMessage("Current todos: ");
            foreach (var todo in allTodos)
            {
                _todosUserInteraction.PrintMessage($"Id: {todo.Id}");
                _todosUserInteraction.PrintMessage($"Text: {todo.Text}");
                _todosUserInteraction.PrintMessage($"Created at: {todo.CreatedAt}");
                _todosUserInteraction.PrintMessage("**********************************");
            }
        }
        _todosUserInteraction.PrintMessage("");
        _todosUserInteraction.PrintMessage("What do you want to do?");
        var shouldExit = false;
        while (shouldExit == false)
        {
            var todoMenuUserOption = _todosUserInteraction.GetMenuOption();
            switch (todoMenuUserOption)
            {
                case (int)TodoMenuActions.Add:
                    AddTodo();
                    break;
                case (int)TodoMenuActions.Edit:
                    EditTodo();
                    break;
                case (int)TodoMenuActions.Delete:
                    DeleteTodo();
                    break;
                case (int)TodoMenuActions.Clear:
                    ClearAllTodos();
                    break;
                case (int)TodoMenuActions.Exit:
                    shouldExit = true;
                    break;
            }
        }
        _todosUserInteraction.Exit();
    }

    private void AddTodo()
    {
        var text = _todosUserInteraction.PromptUser("Create a todo:");
        Todo newTodo = _todosRepository.Add(_filePath, text);
        _todosUserInteraction.PrintMessage($"Added: {newTodo.Id}");
    }

    private void EditTodo()
    {
        _todosUserInteraction.PrintMessage("Choose the id of the todo you want to edit:");
        var todoId = _todosUserInteraction.GetTextFromUser();
        bool itExists = _todosRepository.GetById(_filePath, todoId) is not null;
        if (itExists)
        {
            var newText = _todosUserInteraction.PromptUser("Edit a todo:");
            _todosRepository.Edit(_filePath, todoId, newText);
            _todosUserInteraction.PrintMessage("Todo edited successfully");
        }
        else
        {
            _todosUserInteraction.PrintMessage("Todo not found...");
        }
    }

    private void DeleteTodo()
    {
        var todoId = _todosUserInteraction.PromptUser("Choose the id of the todo you want to delete");
        Todo todoToDelete = _todosRepository.GetById(_filePath, todoId);
        if (todoToDelete is not null)
        {
            _todosRepository.Delete(_filePath, todoToDelete.Id);
            _todosUserInteraction.PrintMessage("Todo deleted successfully");
        }
        else
        {
            _todosUserInteraction.PrintMessage("Todo not found...");
        }
    }

    private void ClearAllTodos()
    {
        _todosRepository.ClearAll(_filePath);
        _todosUserInteraction.PrintMessage("Deleted all todos");
    }
}



