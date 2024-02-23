using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Create a Stopwatch instance
        Stopwatch stopwatch = new Stopwatch();
        Stopwatch stopwatch1 = new Stopwatch();
        int size = 10;

        // Seed for the random number generator
        Random random = new Random();

        // Array to store random integers
        int[] array = new int[size];

        Enumerable.Range(0, size).Select<int, object>(x => { Console.WriteLine(x); return null; });

        // Fill the array with random integers
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(); // Generate a random integer
        }

        int[] array2 = new int[size];

        for (int i = 0; i < size; i++)
        {
            array2[i] = random.Next();
        }

        BubbleSort(array);

        // Start the stopwatch
        stopwatch.Start();

        // Call the method you want to benchmark
        BubbleSort(array);

        // Stop the stopwatch
        stopwatch.Stop();

        // Get the elapsed time in milliseconds
        long elapsedMillisecondsBubble = stopwatch.ElapsedMilliseconds;

        // Output the elapsed time
        Console.WriteLine($"Elapsed Time For Bubble: {elapsedMillisecondsBubble} ms");

        stopwatch1.Start();

        // Call the method you want to benchmark
        Array.Sort(array2);

        // Stop the stopwatch
        stopwatch1.Stop();

        // Get the elapsed time in milliseconds
        long elapsedMillisecondsStandard = stopwatch1.ElapsedMilliseconds;

        // Output the elapsed time
        Console.WriteLine($"Elapsed Time For Standard: {elapsedMillisecondsStandard} ms");
    }

    static int[] BubbleSort(int[] array)
    {
        int[] sortedArray = array;

        for (int row = 0; row < sortedArray.Length - 1; row++)
        {
            for (int col = 0; col < sortedArray.Length - row - 1; col++)
            {
                if (sortedArray[col] > sortedArray[col + 1 ])
                {
                    int temp = sortedArray[col];
                    sortedArray[col] = sortedArray[col + 1];
                    sortedArray[col + 1] = temp;
                }
            }
        }

        return sortedArray;
    }
}
