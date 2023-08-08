namespace TodoApp.Todos;

public interface ITodosUserInteraction
{
    void GetMenuOptionFromUser(out int validOption);
    string GetTextFromUser();
    void PrintMessage(string message);
    int GetMenuOption();
    string PromptUser(string message);
    void Exit();
}
