// Parallel, PLINQ

using System.Collections.Concurrent;
using System.Diagnostics;

Console.WriteLine();

List<Student> students = [];

for (int i = 0; i < 1000000; i++)
{
    students.Add(new Student
    {
        Id = i + 1,
        FirstName = Faker.NameFaker.FirstName(),
        LastName = Faker.NameFaker.LastName(),
        Age = Faker.NumberFaker.Number(18, 78),
        Email = Faker.InternetFaker.Email(),
        Mark = Faker.NumberFaker.Number(10, 120) / 10.0
    });
}
Console.WriteLine("Students add finish!!!");

#region Task Continue WhenAll, WhenAny
//Task task1 = Task.Run(() =>
//{
//    for (int i = 0; i < students.Count / 2; i++)
//    {
//        Task.Delay(1000);
//        students[i].Group = "FSDA_Oct_24_5_az";
//    }
//});
//Task task2 = Task.Run(() =>
//{
//    for (int i = students.Count / 2; i < students.Count; i++)
//    {
//        Task.Delay(1000);
//        students[i].Group = "FSDM_Oct_24_4_az";
//    }
//});

////Task.WaitAll(task1, task2);

//await Task.WhenAll(
//    task1,
//    task2,
//    SendEmailNotification(),
//    SendSMSNotification(),
//    WriteLogData()
//    )
//    .ContinueWith(t =>
//    {
//        Console.WriteLine("Continue with task");
//    });

////students.ForEach(Console.WriteLine);

//Console.WriteLine("End");

//Task SendEmailNotification() => Task.Delay(10000);
//Task SendSMSNotification() => Task.Delay(1);
//Task WriteLogData() => Task.Delay(700);

#endregion


#region Parallel
//Parallel.For(0, students.Count, new ParallelOptions { MaxDegreeOfParallelism = 3},
//    i => {
//        //Thread.Sleep(1);
//        students[i].Group = "FSDA_Oct_24_5_az";
//        Console.WriteLine($"Thread id = {Thread.CurrentThread.ManagedThreadId} - IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
//    });


//Stopwatch stopwatch = new();
//stopwatch.Start();
//for (int i = 0; i < students.Count; i++)
//{
//    Thread.Sleep(1);
//    students[i].Group = "FSDA_Oct_24_5_az";
//}

//var syncTick = stopwatch.ElapsedTicks;
//stopwatch.Restart();

//Parallel.For(0, students.Count,
//    i =>
//    {
//        Thread.Sleep(1);
//        students[i].Group = "FSDA_Oct_24_5_az";
//    });

//var parallelTick = stopwatch.ElapsedTicks;
//stopwatch.Stop();
//Console.WriteLine($"Synchrony for ticks: {syncTick}");
//Console.WriteLine($"Parallel for ticks: {parallelTick}");

#endregion

#region PLINQ
//Stopwatch stopwatch = new();
//stopwatch.Start();
//// LINQ
//var linqCount = students.Count(s => s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"));

//var syncTick = stopwatch.ElapsedTicks;
//stopwatch.Restart();

//var parallelCount = 0;
//// Parllel ForEach
//object obj = new();
//Parallel.ForEach(students,
//    s =>
//    {
//        if (s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
//        {
//            lock (obj)
//            {
//                parallelCount++;
//            }
//            //Interlocked.Increment(ref parallelCount);
//        }
//    });

//var parallelTick = stopwatch.ElapsedTicks;
//stopwatch.Restart();

//// PLINQ
//var plinqCount = students.AsParallel().Count(s => s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"));
//var plinqTick = stopwatch.ElapsedTicks;
//stopwatch.Stop();
//Console.WriteLine($"Synchrony LINQ ticks: {syncTick}");
//Console.WriteLine($"Parallel foreach ticks: {parallelTick}");
//Console.WriteLine($"PLINQ ticks: {plinqTick}");

//Console.WriteLine();

//Console.WriteLine($"Synchrony LINQ count: {linqCount}");
//Console.WriteLine($"Parallel foreach count: {parallelCount}");
//Console.WriteLine($"PLINQ count: {plinqCount}");
#endregion

#region PLINQ VS LINQ VS Parallel with collections
//Stopwatch stopwatch = new();
//stopwatch.Start();
//// LINQ
//var linqNames = students
//    .Where(s => s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
//    .Select(s =>
//    {
//        Thread.Sleep(1);
//        return $"{s.FirstName} {s.LastName}";
//    })
//    .ToList();

//var syncTick = stopwatch.ElapsedTicks;
//stopwatch.Restart();



//List<string> parallelNames = [];
//// Parllel ForEach
//object obj = new();
//Parallel.ForEach(students,
//    s =>
//    {
//        if (s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
//        {
//            Thread.Sleep(1);
//            lock (obj)
//            {
//                parallelNames.Add($"{s.FirstName} {s.LastName}");
//            }
//        }
//    });

//var parallelTick = stopwatch.ElapsedTicks;
//stopwatch.Restart();

//// PLINQ
//var plinqNames = students.AsParallel()
//    .Where(s => s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
//    .Select(s =>
//    {
//        Thread.Sleep(1);
//        return $"{s.FirstName} {s.LastName}";
//    })
//    .ToList();
//var plinqTick = stopwatch.ElapsedTicks;
//stopwatch.Stop();
//Console.WriteLine($"Synchrony LINQ ticks: {syncTick}");
//Console.WriteLine($"Parallel foreach ticks: {parallelTick}");
//Console.WriteLine($"PLINQ ticks: {plinqTick}");

//Console.WriteLine();

//Console.WriteLine($"Synchrony LINQ count: {linqNames.Count}");
//Console.WriteLine($"Parallel foreach count: {parallelNames.Count}");
//Console.WriteLine($"PLINQ count: {plinqNames.Count}");

#endregion

#region PLINQ VS LINQ VS Parallel with ThreadSafe collections
Stopwatch stopwatch = new();
stopwatch.Start();
// LINQ
var linqNames = students
    .Where(s => s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
    .Select(s =>
    {
        Thread.Sleep(10);
        return $"{s.FirstName} {s.LastName}";
    })
    .ToList();

var syncTick = stopwatch.ElapsedTicks;
stopwatch.Restart();



ConcurrentBag<string> parallelNames = [];
// Parllel ForEach
object obj = new();
Parallel.ForEach(students,
    s =>
    {
        if (s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
        {
            Thread.Sleep(10);
            parallelNames.Add($"{s.FirstName} {s.LastName}");
        }
    });

var parallelTick = stopwatch.ElapsedTicks;
stopwatch.Restart();

// PLINQ
var plinqNames = students.AsParallel()
    .Where(s => s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
    .Select(s =>
    {
        Thread.Sleep(10);
        return $"{s.FirstName} {s.LastName}";
    })
    .ToList();
var plinqTick = stopwatch.ElapsedTicks;
stopwatch.Stop();
Console.WriteLine($"Synchrony LINQ ticks: {syncTick}");
Console.WriteLine($"Parallel foreach ticks: {parallelTick}");
Console.WriteLine($"PLINQ ticks: {plinqTick}");

Console.WriteLine();

Console.WriteLine($"Synchrony LINQ count: {linqNames.Count}");
Console.WriteLine($"Parallel foreach count: {parallelNames.Count}");
Console.WriteLine($"PLINQ count: {plinqNames.Count}");

#endregion