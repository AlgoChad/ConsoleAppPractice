using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection.Metadata;

class Program
{
    public class Entity
    {
        public string Name { get; set;}
        public int randomVal { get; set; }
    }

    static async Task Main(string[] args)
    {
        await TaskToRun();
    }

    static async Task TaskToRun()
    {
     
        string[] firstNames = [
                    "Emma",
            "Liam",
            "Olivia",
            "Noah",
            "Ava",
            "Sophia",
            "Jackson",
            "Isabella",
            "Lucas",
            "Mia",
            "Aiden",
            "Amelia",
            "Elijah",
            "Harper",
            "Oliver",
            "Abigail",
            "Ethan",
            "Ella",
            "Logan",
            "Scarlett"
                ];

        string[] lastNames = [
            "Smith",
            "Johnson",
            "Williams",
            "Jones",
            "Brown",
            "Davis",
            "Miller",
            "Wilson",
            "Moore",
            "Taylor",
            "Anderson",
            "Thomas",
            "Jackson",
            "White",
            "Harris",
            "Martin",
            "Thompson",
            "Garcia",
            "Martinez",
            "Robinson"
        ];

        Random random = new Random();

        ConcurrentBag<Entity> concurrentEntityList = new ConcurrentBag<Entity>();

        Entity[] objectArray = new Entity[100000];
        List<Entity> objectList = new List<Entity>();

        for (int i = 0; i < objectArray.Length; i++)
        {
            string first = firstNames[random.Next(firstNames.Length)];
            string last = lastNames[random.Next(lastNames.Length)];

            objectArray[i]  = new Entity
            {
                Name = $"{first} {last}",
                randomVal = random.Next()
            };
        }

        for (int i = 0; i < 100000; i++)
        {
            string first = firstNames[random.Next(firstNames.Length)];
            string last = lastNames[random.Next(lastNames.Length)];

            Entity newEntity = new Entity
            {
                Name = $"{first} {last}",
                randomVal = random.Next()
            };

            objectList.Add(newEntity);
        }

        await Task.Delay(1000);
        
        Console.WriteLine("Starting to Sort.");

        Stopwatch listStopWatch= new Stopwatch();

        listStopWatch.Start();

        //var sortedListData = BubbleSort(integerList);

        var sortedObjectList = objectList.OrderBy(n => n.randomVal).ToList();

        listStopWatch.Stop();

        long elapsedMillisecondsOne = listStopWatch.ElapsedMilliseconds;


        Stopwatch arrayStopWatch = new Stopwatch();

        arrayStopWatch.Start();

        //var sortedData = BubbleSort(integerArray);

        var sortedObjectArray = objectArray.OrderBy(n => n.randomVal).ToArray();

        arrayStopWatch.Stop();

        long elapsedMilliseconds = arrayStopWatch.ElapsedMilliseconds;


        Console.WriteLine($"Elapsed Time of Object Sort in Array: {elapsedMilliseconds} ms");

        Console.WriteLine($"Elapsed Time of Ojbect Sort in List: {elapsedMillisecondsOne} ms");

        PrintCollection(sortedObjectArray.Where(data => data.Name == "Ella Thomas").ToList());

        // Start the stopwatch
        stopwatch.Start();

        // Call the method you want to benchmark
        MyMethodToBenchmark();

    public static int[] BubbleSort(int[] array)
    {
        int[] sortedArray = array;

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