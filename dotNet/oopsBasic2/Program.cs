using System;

sealed class User
{
    public User(string name, string email)
    {
        Name = name;
        EmailId = email;
    }
    public string Name { get; set; } // Removed 'required'
    public string EmailId { get; set; } // Removed 'required'
}

class BaseStudent
{
    public virtual void ShowDetails() // virtual helps in runtime polymorphism
    {
        Console.WriteLine("Base Student Details");

    }
}

class Student : BaseStudent
{
    public Student(string usn)
    {
        Usn = usn;
    }
    public string Usn { get; set; } // Removed 'required'

    public override void ShowDetails()
    {
        Console.WriteLine($"USN: {Usn}");
    }
}

public class Program
{
    static void Main()
    {
        Student student = new Student(usn: "12345CT");
        Console.WriteLine($"USN: {student.Usn}"); //Formatted output
        student.ShowDetails();
    }
}
