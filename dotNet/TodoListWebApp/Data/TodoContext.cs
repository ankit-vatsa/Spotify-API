using Microsoft.EntityFrameworkCore; //Imports Entity Framework Core (EF Core) Library to interact with database
using TodoListWebApp.Models;         //Imports Models namespace to fetch Todo class that we defined

namespace TodoListWebApp.Data        //Namespaces help organize code and avoid naming conflicts.
{
    //DbContext, which is a built-in EF Core class that manages database connections and operations.

    public class TodoContext : DbContext //Inherited from DbContext class
    {
        //Constructor that accepts DbContextOptions<TodoContext> as a parameter.
        /*  Where does "options" come from?
                options is defined and set in Program.cs
            options contains database configuration settings (e.g., database type, connection string).
            The base(options) calls the DbContext constructor in EF Core, applying the configuration.
        */
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

        //"DbSet<Todo>" represent a table
        //"<Todo>" is the model we defined  

        public DbSet<Todo> Todos { get; set; } // Defines a Table named "Todos" in DB to store ToDo items
        /*
        This allows us to perform operations like:
            Insert new tasks → _context.Todos.Add(new Todo { Title = "Learn C#" });
            Retrieve tasks   → _context.Todos.ToListAsync();
            Delete tasks     → _context.Todos.Remove(todo);
            Update tasks     → todo.IsCompleted = true;
        */
    }
}