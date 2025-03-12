using System;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Starting asynchronous operations...");

        // Start two asynchronous tasks
        Task<int> task1 = PerformLongRunningOperationAsync(1, 3000); // 3 seconds delay
        Task<string> task2 = PerformAnotherLongRunningOperationAsync("Example_Text", 2000); // 2 seconds delay

        // Wait for both tasks to complete and retrieve their results
        await Task.WhenAll(task1, task2);

        // Process the results
        int result1 = task1.Result;
        string result2 = task2.Result;

        Console.WriteLine($"Task 1 result: {result1}");
        Console.WriteLine($"Task 2 result: {result2}");

        Console.WriteLine("Asynchronous operations completed.");
    }

    public static async Task<int> PerformLongRunningOperationAsync(int id, int delayMilliseconds)
    {
        Console.WriteLine($"Task {id} started. Delay: {delayMilliseconds}ms");
        await Task.Delay(delayMilliseconds); // Simulate a long-running operation
        Console.WriteLine($"Task {id} completed.");
        return id * 10; // Return a result
    }

    public static async Task<string> PerformAnotherLongRunningOperationAsync(string data, int delayMilliseconds)
    {
        Console.WriteLine($"Task 2 started. Delay: {delayMilliseconds}ms");
        await Task.Delay(delayMilliseconds); // Simulate a long-running operation
        Console.WriteLine("Task 2 completed.");
        return $"{data} processed"; // Return a result
    }
}
