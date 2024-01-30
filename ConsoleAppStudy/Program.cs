using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Create a Stopwatch instance
        Stopwatch stopwatch = new Stopwatch();

        // Start the stopwatch
        stopwatch.Start();

        // Call the method you want to benchmark
        MyMethodToBenchmark();

        // Stop the stopwatch
        stopwatch.Stop();

        // Get the elapsed time in milliseconds
        long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

        // Output the elapsed time
        Console.WriteLine($"Elapsed Time: {elapsedMilliseconds} ms");
    }

    static void MyMethodToBenchmark()
    {
        int sum = 0;
        // Your code to benchmark here
        for (int i = 0; i < 1000000; i++)
        {
            sum += i;
        }
    }
}
