/*
Key OOP Concepts Used
✅ Inheritance (Student : User)
Student inherits from User, meaning it gets the Name and EmailId properties automatically.
✅ Constructor Chaining (base(name, email))
The Student constructor calls the User constructor using base(name, email), ensuring properties are initialized correctly.
✅ Encapsulation (Properties)
The properties Name, EmailId, and Usn use getters and setters, allowing controlled access to object data.

*/
public class User
{
    public User(string name, string email)
    {
        Name = name;
        EmailId = email;
    }
    public string Name { get; set; } 
    public string EmailId { get; set; } 
}

public class Student : User
{
    public Student(string name, string email, string usn) : base(name, email) //Calls the base class constructor base(name, email) to initialize Name and EmailId.
    {
        Usn = usn;
    }
    public string Usn { get; set; } 
}

public class Program
{
    static void Main()
    {
        //Student student = new Student(name: "Vishwas", email: "vishwas@cloudthat.com", usn: "12345CT");
        Student student = new Student("Vishwas", "vishwas@cloudthat.com", "12345CT");
        System.Console.WriteLine($"Name: {student.Name}, Email: {student.EmailId}, USN: {student.Usn}");
    }
}

