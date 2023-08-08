using TodoApp.DataAccess;
using TodoApp.Todos;

var todosUserInteraction = new TodosUserInteraction();
var stringsJsonRepository = new StringsJsonRepository();
var todosRepository = new TodosRepository(stringsJsonRepository);

var todoApp = new TodoApplication(todosUserInteraction, todosRepository, "todos", "json");
todoApp.Run();