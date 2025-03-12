using Microsoft.EntityFrameworkCore; //Imports EF core to handle database interactions
using TodoListWebApp.Data; //Imports our database context

//"builder" object is used to configure - services and middleware before running the app.
var builder = WebApplication.CreateBuilder(args); //Creates a new web application using WebApplication.CreateBuilder(args)

// Registers Razor Pages so the application can serve .cshtml pages.
builder.Services.AddRazorPages();

//Register In-Memory Database
builder.Services.AddDbContext<TodoContext>(options =>
{
    options.UseInMemoryDatabase("TodoList");
});

//Calls .Build() to finalize the app setup after adding all the services.
var app = builder.Build();
//app now represents the configured web application.

// Configure the HTTP request pipeline. - Middleware
if (!app.Environment.IsDevelopment()) //Checks if the app is running in Production Mode (!app.Environment.IsDevelopment())
{
    //if app NOT in development mode redirect errors to Error page.
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); //Redirects HTTP requests to HTTPS for security.
app.UseStaticFiles(); //Allows the app to serve CSS, JavaScript, images, and other static files.

app.UseRouting(); //Enables routing, which helps direct user requests to the right page.

//Not needed now because we don’t have authentication yet, but
app.UseAuthorization(); //Enables authorization, which controls who can access certain pages.

app.MapRazorPages(); //Tells ASP.NET Core to use Razor Pages (.cshtml files) for handling requests.

app.Run(); //Starts the web application.

