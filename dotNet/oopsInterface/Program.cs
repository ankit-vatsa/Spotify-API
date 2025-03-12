// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
/*
C# program demonstrates object-oriented programming (OOP) concepts, including abstraction, inheritance, polymorphism, interfaces, and method overriding.

Key OOP Concepts Used:
    Abstraction – Shape defines a common interface for all shapes.
    Inheritance – Circle and DrawableCircle inherit from Shape.
    Polymorphism – Display() and CalculaterArea() are overridden in derived classes.
    Interfaces – IDrawable and IResizable allow adding behaviors (Draw(), Resize()) to DrawableCircle.
*/
public abstract class Shape
{
    /*
 Abstraction is an OOP principle that hides complex implementation details and only exposes the necessary parts.
    Shape is an abstract class.
    Shape does not define CalculaterArea()—it only declares it.
    Circle implements the logic for CalculaterArea().
    The user does not need to know how CalculaterArea() works; they just call it.

Shape is an abstract class:
        It cannot be instantiated directly.
        It contains an abstract method CalculaterArea(), which must be implemented by derived classes.
        It also has a virtual method Display(), which can be overridden by derived classes.

    */
    public abstract double CalculaterArea();
    public virtual void Display()
    {
        Console.WriteLine("Displaying shape");
    }
}
public class Circle : Shape
{
    public double Radius { get; set; }
    public Circle(double radius)
    {
        Radius = radius;
    }
    public override double CalculaterArea()
    {
        return Math.PI * Radius * Radius;
    }
    public override void Display()
    {
        Console.WriteLine($"Displaying Circle: R={Radius}, Area = {CalculaterArea()}");
    }
}
/*
Interfaces define behaviors that classes can implement.

An interface in C# is like a contract that defines a set of methods that a class must implement. 
It does not contain implementations, only provide method signatures.

A behavior refers to what an object can do. In OOP, behaviors are defined through methods.

Example Behaviors in the Code:
    Draw() in IDrawable → Defines the behavior of drawing a shape.
    Resize(double factor) in IResizable → Defines the behavior of resizing a shape.
    Display() in Shape and Circle → Defines the behavior of displaying shape details.
    CalculaterArea() in Shape and Circle → Defines the behavior of calculating area.
*/
public interface IDrawable
{
    void Draw();
}
public interface IResizable
{
    void Resize(double factor);
}
public class DrawableCircle : Circle, IDrawable, IResizable
{
    public DrawableCircle(double radius) : base(radius) 
    { 
    }
    public void Draw()
    {
        Console.WriteLine("Drawing a circle");
    }
    public void Resize (double factor) 
    {
        Radius *= factor;
        Console.WriteLine($"Resizing the circle");
    }
}
public class Program
{
    public static void Main()
    {
        Console.WriteLine("\nCircle class begins:\n");
        Circle circle = new Circle(5);
        Console.WriteLine("Circle Display() function calling:\n".PadLeft((Console.WindowWidth) / 2));
        circle.Display();

        Console.WriteLine("\nDrawable Circle begins:\n");
        DrawableCircle drawableCircle = new DrawableCircle(10);
        Console.WriteLine("\nCalculaterArea() function calling:\n");
        drawableCircle.CalculaterArea();
        Console.WriteLine("\nResize() function calling:\n");
        drawableCircle.Resize(2);
        Console.WriteLine("Display() function calling:\n".PadLeft((Console.WindowWidth) / 2));
        drawableCircle.Display();

    }
}

