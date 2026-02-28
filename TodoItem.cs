//models represent the structure of data and help usto define the properties and behavior of the data we are working with. In this case, we have a TodoItem model that represents a single item in our todo list. It has three properties: Id, Title, and IsCompleted. The Id property is an integer that serves as a unique identifier for each todo item. The Title property is a string that represents the title or description of the todo item, and it is initialized to an empty string to ensure that there are no null values. The IsCompleted property is a boolean that indicates whether the todo item has been completed or not. By defining this model, we can easily create, read, update, and delete todo items in our application.
namespace SimpleTodoAPI.Models;
    public class TodoItem
    {
        public int Id{get; set;}
        //string.Empty ensures that ther are no null values for the Title property.
public string Title {get; set;}= string.Empty;
public bool IsCompleted{get;set;}
    }