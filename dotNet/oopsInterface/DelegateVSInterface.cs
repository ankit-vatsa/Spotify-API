using System;

// Define an interface with a method signature
public interface IDrawable
{
    void Draw();  // This is just the signature, classes must implement it
}

// Define a delegate that matches a method signature
public delegate void DrawDelegate();  // This is a signature without implementation

public class Circle : IDrawable
{
    // Implementing the Draw method from the IDrawable interface
    public void Draw()
    {
        Console.WriteLine("Drawing a Circle");
    }
}

public class Square : IDrawable
{
    // Implementing the Draw method from the IDrawable interface
    public void Draw()
    {
        Console.WriteLine("Drawing a Square");
    }
}

public class Program
{
    // Method that matches the delegate signature
    public static void DrawCircle()
    {
        Console.WriteLine("Circle drawn through delegate");
    }

    public static void Main()
    {
        // Interface Example: Enforcing method implementation
        IDrawable circle = new Circle();
        circle.Draw();  // Output: Drawing a Circle
        
        IDrawable square = new Square();
        square.Draw();  // Output: Drawing a Square

        // Delegate Example: Dynamically invoking methods
        DrawDelegate drawDelegate = new DrawDelegate(DrawCircle);  // Assigning method to delegate
        drawDelegate();  // Output: Circle drawn through delegate
        
        // You can also add more methods dynamically to the delegate
        drawDelegate += () => Console.WriteLine("Another method called");
        /*
        "drawDelegate" already has a method assigned to it.
        
        "+=" operator is used to add a new method to the delegate's invocation list (multicast delegate).
        After this operation, the drawDelegate will invoke both the previously assigned method(s) and the 
        newly added method(s) when it is called.

        The lambda expression is a shorthand syntax for creating an anonymous method.
        
        () => Console.WriteLine("Another method called") (Lambda Expression):

        The "()" represents no parameters (i.e., the method doesn't take any input).
        The "=>" is the lambda operator, which separates the parameters from the method body.
        "Console.WriteLine("Another method called")" is the body of the lambda expression. 
        When this lambda is invoked, it will output the string "Another method called" to the console.
        */
        drawDelegate();  // Output: Circle drawn through delegate, Another method called
    }
}

