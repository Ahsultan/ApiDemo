using ApiDemo.Models;

namespace ApiDemo.Data
{
    public class TodoRepository
    {

    public Todo[] sampleTodos = new Todo[] {
    new(1, "Walk the dog"),
    new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
    new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
    new(4, "Clean the bathroom"),
    new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
    };

    public TodoRepository() { }
    public List<Todo> GetAllTodos()
        {
            return sampleTodos.ToList();
        }

    public Todo GetById(int id)
        {
            return sampleTodos[id];
        }

    }
}
