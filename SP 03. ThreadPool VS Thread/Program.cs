// ThreadPool VS Thread
using System.Diagnostics;

int operationCount = 1000;
var watch = new Stopwatch();

watch.Start();
UseThread(operationCount);
//for (int i = 0; i < 100000; i++)
//{
//    operationCount += i;
//}
watch.Stop();

Console.WriteLine($"{watch.ElapsedMilliseconds} milliseconds");

watch.Reset();

watch.Start();
//Thread.Sleep(1);
UseThreadPool(operationCount);
watch.Stop();

Console.WriteLine($"{watch.ElapsedMilliseconds} milliseconds");
Console.ReadLine();
void UseThread(int operationCount)
{
    List<int> ids = new List<int>();
    using (var count = new CountdownEvent(operationCount))
    {
        Console.WriteLine("Threads...");
        for (int i = 0; i < operationCount; i++)
        {
            var thread = new Thread(() =>
            {
                Thread.Sleep(1000);
                // Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                if(!ids.Contains(Thread.CurrentThread.ManagedThreadId)) 
                    ids.Add(Thread.CurrentThread.ManagedThreadId);
                count.Signal();
            });
            thread.Start();

        }
        count.Wait();
    }
    Console.WriteLine($"Threads count {ids.Count}");
}

void UseThreadPool(int operationCount)
{
    List<int> ids = new List<int>();
    using (var count = new CountdownEvent(operationCount))
    {
        Console.WriteLine("Threads...");
        for (int i = 0; i < operationCount; i++)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                Thread.Sleep(1000);
                // Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                if(!ids.Contains(Thread.CurrentThread.ManagedThreadId))
                    ids.Add(Thread.CurrentThread. ManagedThreadId);
                count.Signal();
            });
        }
        count.Wait();
    }
    Console.WriteLine($"ThreadPool used threads count {ids.Count}");
}