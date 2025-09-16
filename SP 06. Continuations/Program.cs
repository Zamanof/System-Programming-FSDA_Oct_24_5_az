// Continuations

#region ContinueWith OnlyOnRanToCompletation
//var firstTask = new Task<int>(()=> TaskReturnMethod("First Task", 3));
//var secondTask = new Task<int>(()=> TaskReturnMethod("Second Task", 5));

//firstTask.ContinueWith(t =>
//{
//    Console.WriteLine("ContinueWith task start");
//    Console.WriteLine($@"
//Result:             {t.Result}
//Thread Id:          {Thread.CurrentThread.ManagedThreadId}
//IsBackground:       {Thread.CurrentThread.IsBackground}
//IsThreadPool:       {Thread.CurrentThread.IsThreadPoolThread}
//");

//    Console.WriteLine("ContinueWith task end");
//}, TaskContinuationOptions.OnlyOnRanToCompletion);

//secondTask.ContinueWith(t =>
//{
//    OtherMethod();
//}, TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted);

//firstTask.Start();
//secondTask.Start();
//Console.ReadLine();
#endregion

#region ContinueWith OnlyOnFaulted
//try
//{
//    var firstTask = new Task<int>(() => TaskReturnMethod("First Task", 3));
//    firstTask.ContinueWith(t =>
//    {
//        Console.WriteLine("ContinueWith task start");
//        Console.WriteLine($@"
//Thread Id:          {Thread.CurrentThread.ManagedThreadId}
//IsBackground:       {Thread.CurrentThread.IsBackground}
//IsThreadPool:       {Thread.CurrentThread.IsThreadPoolThread}
//");

//        Console.WriteLine("ContinueWith task end");
//    }, TaskContinuationOptions.OnlyOnFaulted);


//    firstTask.Start();
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}


//Console.ReadLine();
#endregion

#region ContinueWith with Thread
//var firstTask = new Task<int>(() => TaskReturnMethod("First Task", 3));

//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine("ContinueWith task Start");
//    Console.WriteLine($@"Id:             {Thread.CurrentThread.ManagedThreadId}
//IsBackground:   {Thread.CurrentThread.IsBackground}
//IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}");
//    Console.WriteLine("ContinueWith task End");
//}, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.LongRunning);
//firstTask.Start();

//Console.ReadLine();
#endregion

#region ContinueWith ExecuteSyncronously
//var firstTask = new Task<int>(() => TaskReturnMethod("First Task", 3));

//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine("ContinueWith task Start");
//    Console.WriteLine($@"Id:             {Thread.CurrentThread.ManagedThreadId}
//IsBackground:   {Thread.CurrentThread.IsBackground}
//IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}");
//    Console.WriteLine("ContinueWith task End");
//}, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);
//firstTask.Start();

//Console.ReadLine();
#endregion

#region Task.Status
// Created
// WaitingForActivation
// WaitingToRun
// Running
// WaitingForChildrenToComplete
// RanToCompletion
// Canceled
// Faulted
var firstTask = new Task<int>(() => TaskReturnMethod("First Task", 3));
try
{
    Console.WriteLine(firstTask.Status);
    firstTask.Start();
    while (true)
    {
        Console.WriteLine(firstTask.Status);
        Thread.Sleep(100);
        if (firstTask.IsCompleted) break;
    }
    firstTask.Wait();
    Console.WriteLine(firstTask.Status);
}
catch (Exception)
{
    Console.WriteLine(firstTask.Status);
}


#endregion

int TaskReturnMethod(string name, int second)
{
    Console.WriteLine($"Task - {name} start");
    Console.WriteLine($@"
Thread Id:          {Thread.CurrentThread.ManagedThreadId}
IsBackground:       {Thread.CurrentThread.IsBackground}
IsThreadPool:       {Thread.CurrentThread.IsThreadPoolThread}
");

    Thread.Sleep(TimeSpan.FromSeconds(second));
    Console.WriteLine($"Task - {name} end");
    //throw new Exception("Kral oldu, yashasin kral.");
    return second * 10;
}

void OtherMethod()
{
    Console.WriteLine("Other method start");
    Console.WriteLine($@"
Thread Id:          {Thread.CurrentThread.ManagedThreadId}
IsBackground:       {Thread.CurrentThread.IsBackground}
IsThreadPool:       {Thread.CurrentThread.IsThreadPoolThread}
");
    Thread.Sleep(1000);
    Console.WriteLine("Other method end");
}
