// Thread -> ThreadPool -> Task -> syntax sugar + love = async await
using System.Net;


Console.WriteLine($"Main Method start in thread: {Thread.CurrentThread.ManagedThreadId}"); // Main thread

//SomeMethod();
//SomeMethodAsync();
WebClient webClient = new();
string url = @"https://www.youtube.com/";
var task = webClient.DownloadStringTaskAsync(url);
Console.WriteLine(task.Result);

Console.WriteLine($"Main Method end in thread: {Thread.CurrentThread.ManagedThreadId}"); // Main thread
Console.ReadLine();
void SomeMethod()
{
    // Main thread
    Console.WriteLine($"SomeMethod start in thread: {Thread.CurrentThread.ManagedThreadId}");
    var task = Task.Run<int>(() =>
    {
        // ThreadPool thread
        Console.WriteLine($"SomeMethod inner task start in thread: {Thread.CurrentThread.ManagedThreadId}");

        Thread.Sleep(3000);

        // Same ThreadPool thread where started
        Console.WriteLine($"SomeMethod inner task end in thread: {Thread.CurrentThread.ManagedThreadId}");
        return 16456;
    });

    // Main thread
    Console.WriteLine($"SomeMethod end in thread: {Thread.CurrentThread.ManagedThreadId}; Result = {task.Result}");
}

async void SomeMethodAsync()
{
    
    // Main thread
    Console.WriteLine($"SomeMethod start in thread: {Thread.CurrentThread.ManagedThreadId}");
    var result = await Task.Run<int>(() =>
    {
        // ThreadPool thread
        Console.WriteLine($"SomeMethod inner task start in thread: {Thread.CurrentThread.ManagedThreadId}");

        Thread.Sleep(3000);

        // Same ThreadPool thread where started
        Console.WriteLine($"SomeMethod inner task end in thread: {Thread.CurrentThread.ManagedThreadId}");
        return 16456;
    });
    // Main thread
    Console.WriteLine($"SomeMethod end in thread: {Thread.CurrentThread.ManagedThreadId}; Result = {result}");
}
