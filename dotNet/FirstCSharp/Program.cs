// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("Ankit Vatsa's first C# app.");
string name = "Ankit";
Console.WriteLine("Hello "+name);//printing variable value with Hello
Console.WriteLine(name);//printing variable value
Console.WriteLine("Hello {0}", name); //"Hello {0}" is a composite format string, where {0} is a placeholder for a value.
/*
The placeholder {0} in Console.WriteLine("Hello {0}", name); is used to dynamically insert a value into the string at runtime. 
This allows you to format and display data without manually concatenating strings.

How the Placeholder Works
1. {0} is a format item (or placeholder) that gets replaced by the first argument after the format string (name in this case).

2. If you have multiple placeholders ({0}, {1}, {2}, etc.), they correspond to additional arguments provided.

Example:

string firstName = "Ankit";
string lastName = "Vatsa";
int age = 25;

Console.WriteLine("Name: {0} {1}, Age: {2}", firstName, lastName, age);

Output:
Name: Ankit Vatsa, Age: 25

*/

Console.WriteLine($"Hello, Mr. {name}"); //We can achieve the same result as above using string interpolation (introduced in C# 6.0)

//From here lab begins.


Console.WriteLine("\n\nFrom here Lab begins.\n");

/*
Lab: Given a string, Write a program to  print the left aligned, right aligned, center aligned text considering 
Maximum screen length as 80 Characters. 
*/
int screenLength= 80;
Console.WriteLine("Screenlength given is : {0} \n", screenLength);

//Left Aligned
Console.WriteLine("\nLeft Aligned"); //already aligned so no external function needed
Console.WriteLine($"Hello, {name}");

//Center Aligned
Console.WriteLine("\nCenter Aligned");
int centralLength = (screenLength-name.Length)/2;
Console.WriteLine($"Hello, {name}".PadLeft(centralLength+name.Length));

//Right Aligned
Console.WriteLine("\nRight Aligned");
Console.WriteLine($"Hello, {name}".PadLeft(screenLength)); //.PadLeft() function

//DYNAMIC SCREENLENGTH DETECTION
int dynamicscreenLength = Console.WindowWidth;
Console.WriteLine("Dynamic screenlength detected is : {0} \n\n\n",dynamicscreenLength);
int dynamicCenter = (dynamicscreenLength-6)/2;

/*
USERNAME EXTRACTOR
        Taking email id from the user, extract the username.
        Example: ankit@deloitte.com
        User name part is : ankit
        Domain name is : deloitte.com
*/
Console.WriteLine("Lab: 2".PadLeft(dynamicCenter+6));

Console.WriteLine("Please enter your email:\n");
string emailInput = Console.ReadLine();

Console.WriteLine("\nProvided mail is : {0}", emailInput);

if (emailInput.Contains('@')){

    Console.WriteLine("Your username is: {0}\n", emailInput.Split('@')[0]);
    Console.WriteLine("Your domain is: {0}\n", emailInput.Split('@')[1]);
}
else
{
    Console.WriteLine("Email is not valid.");
}
