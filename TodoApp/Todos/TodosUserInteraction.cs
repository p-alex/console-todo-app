namespace TodoApp.Todos;

public class TodosUserInteraction : ITodosUserInteraction
{
    private readonly string[] _todoActions = {
            "Add a todo",
            "Edit a todo",
            "Delete a todo",
            "Clear all todos",
            "Exit",
        };
    public void PrintMessage(string message) => Console.WriteLine(message);
    public int GetMenuOption()
    {
        int option = 0;
        bool shouldExit = false;
        while (shouldExit == false)
        {
            PrintTodoMenu();
            GetMenuOptionFromUser(out option);
            if (option >= 1 && option <= _todoActions.Length)
            {
                shouldExit = true;
            }
        }
        return option;
    }
    public string PromptUser(string message)
    {
        PrintMessage(message);
        return GetTextFromUser();
    }
    public void GetMenuOptionFromUser(out int validOption)
    {
        var option = GetTextFromUser();
        int.TryParse(option, out validOption);
    }
    public string GetTextFromUser()
    {
        return Console.ReadLine();
    }
    public void Exit()
    {
        PrintMessage("Press any key to exit.");
        Console.ReadKey();
    }
    private void PrintTodoMenu()
    {
        var count = 1;
        foreach (var action in _todoActions)
        {
            PrintMessage($"{count}.{action}");
            ++count;
        }
    }
}
