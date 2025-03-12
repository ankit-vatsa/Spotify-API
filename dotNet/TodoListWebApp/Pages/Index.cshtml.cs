using Microsoft.AspNetCore.Mvc;//Imports features like IActionResult and RedirectToPage(), which handle requests and responses.
using Microsoft.AspNetCore.Mvc.RazorPages; // Enables support for Razor Pages (which are .cshtml files).
using Microsoft.EntityFrameworkCore; // Provides Entity Framework Core (EF Core) functionality for database operations.
using TodoListWebApp.Data; //Imports the TodoContext class, which represents our database.
using TodoListWebApp.Models; //Imports the Todo model, which represents tasks in the database.

//Defines a namespace TodoListWebApp.Pages (to organize code).
namespace TodoListWebApp.Pages
{   //PageModel helps separate UI (HTML) and logic (C#) in Razor Pages.
    public class IndexModel : PageModel //Inherits from PageModel, which is the base class for Razor Pages.
    {
        private readonly ILogger<IndexModel> _logger; //Stores a logging object (not used in this code).
        private readonly TodoContext _context; //Stores a reference to TodoContext, which handles database operations (CRUD).

        //ASP.NET automatically provides logger and context when this class is created.
        //Stores them in _logger and _context for later use.
        //"context" comes from Program.cs from builder.Services.AddDbContext<TodoContext>(options =>
        public IndexModel(ILogger<IndexModel> logger, TodoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Todo> Todos { get; set; } = new(); //Declares a list of Todo objects.
        // It is Used to store tasks fetched from the database and used in OnGetAsync(), where tasks are loaded into Todos.

        public async Task OnGetAsync() //Runs when the page loads (GET request) or user visits Index.cshtml.
        {
            Todos = await _context.Todos.ToListAsync(); //Fetches all tasks from the database and stores them in Todos.
            //ToListAsync() converts the database result into a list.
        }

        //"title" comes from Index.cshtml form input of name="title"
        public async Task<IActionResult> OnPostAddAsync(string title) //Runs when the user submits the "Add" form (POST request).
        {
            if (string.IsNullOrWhiteSpace(title)) // Checks if input is empty or null and If yes, does nothing.
            {
                return RedirectToPage();
            }
            var todo = new Todo //Creates a new Todo object with the provided input.
            {
                Title = title
            };
            _context.Todos.Add(todo); //Adds the input to the database 
            await _context.SaveChangesAsync(); //Saves changes 
            return RedirectToPage(); //Reloads the page to input new tasks
        }

        public async Task<IActionResult> OnPostToggleAsync(int id) //Toggles the IsCompleted status (true and false).
        { // "id" comes from asp-route-id="@todo.Id" in Index.cshtml
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                todo.IsCompleted = !todo.IsCompleted;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id) //Delete tasks from database
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}