// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;

Console.WriteLine("Hello, World! This is my GPA Calculator.\n");
Console.WriteLine("Follow the instructions to get your report card with Grades.\n");

Console.WriteLine("Enter your name:\n");
string fullName = Console.ReadLine();

int[] marks = new int[5];
int[] credits = {3,3,4,4,3};
double[] result = new double[5];
string[] classNames = {"English 101", "Algebra 101", "Biology 101", "Computer Science", "Psychology 101"};
int creditSum= 0;
double resultSum= 0;
for (int i = 0; i< marks.Length; i++)
{
    Console.WriteLine("Enter Grade in the class " + classNames[i]);
    marks[i]=Convert.ToInt32(Console.ReadLine());
    result[i] = marks[i] * credits[i];
    creditSum += credits[i];
    resultSum += result[i];
}

Console.WriteLine($"\n\nStudent: {fullName} \n\n");

Console.WriteLine("{0,-20} {1, -10} {2,-10}\n ", "Course", "Grade", "Credit Hours");
//Console.WriteLine("Course               Grade       Credit Hours");
for (int i = 0; i < marks.Length; i++)
{
    //Console.WriteLine(classNames[i] + "     "+ marks[i]+" " + credits[i]);
    Console.WriteLine("{0,-20} {1, -10} {2,-10}", classNames[i], marks[i], credits[i]);
}
double gpa = resultSum / creditSum;
Console.WriteLine($"\n\nFinal GPA: {gpa:F2}");
Console.WriteLine("\nGrade scored is : ");

gpa = gpa*100/4;
if (gpa > 97) {
    Console.WriteLine("A+");
}
else if (gpa > 93 &&  gpa < 96)
{
    Console.WriteLine("A");
}
else if (gpa > 90 && gpa < 92)
{
    Console.WriteLine("A-");
}
else if (gpa > 87 && gpa < 89)
{
    Console.WriteLine("B+");
}
else if (gpa > 83 && gpa < 86)
{
    Console.WriteLine("B");
}
