using Microsoft.AspNetCore.Mvc;
using SimpleTodoAPI.Models;


namespace SimpleTodoAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class TodoController :ControllerBase
    {
  //Static List(our temporary database) that stores our todo items. It is initialized with two sample todo items for demonstration purposes. Each todo item has an Id, a Title, and an  IsCompleted status. The Id is used to uniquely identify each todo item, while the Title provides a description of the task, and the IsCompleted property indicates whether the task has been completed or not. This list allows us to perform CRUD (Create, Read, Update, Delete) operations on our todo items without needing a real database. 
        private static List<TodoItem> _todos = new List<TodoItem>
        {
          new TodoItem{Id=1,Title="Learn ASP.NET Core",IsCompleted=false},
          new TodoItem{Id=2,Title="Connect model to controller",IsCompleted=false}
        };
  //GET;api/todos    Retrieves data from the server. In this case, it returns a list of all todo items. The method is decorated with the [HttpGet] attribute, which indicates that it will handle HTTP GET requests. When a client sends a GET request to the specified route (api/todos), this method will be invoked, and it will return an ActionResult containing an IEnumerable of TodoItem objects. The Ok() method is used to return a successful response with the list of todo items as the content.
  [HttpGet("{id}")]
  public ActionResult GetTodos(int id)
  {
    var todo = _todos.FirstOrDefault(t => t.Id == id);
    if (todo == null)
    {
      return NotFound($"Todo item with ID{id}not found");
    }

    return Ok(todo);
  }
  //POST:api/todos      Creates data and adds something new to the server. In this case, it creates a new todo item and adds it to the list of existing todo items. The method is decorated with the [HttpPost] attribute, which indicates that it will handle HTTP POST requests. When a client sends a POST request to the specified route (api/todos) with a new todo item in the request body, this method will be invoked. It takes a TodoItem object as a parameter, which represents the new todo item to be created. The method assigns a unique Id to the new todo item by calculating it based on the current count of existing todo items. Then, it adds the new todo item to the list of existing todo items. Finally, it returns a response indicating that the new todo item has been successfully created, along with the details of the newly created item.

  [HttpPost]
  public IActionResult AddTodo(TodoItem newItem)
  {
    newItem.Id = _todos.Count + 1;
    _todos.Add(newItem);
    return Ok(newItem);
  }
  //PUT:api/todos/{id}     Updates existing todoItem. In this case, it updates an existing todo item based on its unique identifier (Id). The method is decorated with the [HttpPut("{id}")] attribute, which indicates that it will handle HTTP PUT requests to the specified route (api/todos/{id}). When a client sends a PUT request to this route with an updated todo item in the request body, this method will be invoked. It takes an integer parameter (id) that represents the unique identifier of the todo item to be updated, and a TodoItem object (updatedItem) that contains the new values for the todo item. The method first checks if a todo item with the specified Id exists in the list of existing todo items. If it does not exist, it returns a NotFound response indicating that the item was not found. If it does exist, it updates the properties of the existing todo item with the values from the updatedItem object. Finally, it returns an Ok response indicating that the update was successful, along with the details of the updated todo item.

  [HttpPut("{id}")]
  public IActionResult UpdateTodo(int id, TodoItem updateItem)
  {
    var todo = _todos.FirstOrDefault(t => t.Id == id);
    if (todo == null)
    {
      return NotFound($"Todo item with ID{id}not found.");
    }
    todo.Title = updateItem.Title;
    todo.IsCompleted = updateItem.IsCompleted;
    return Ok(todo);
} 
}