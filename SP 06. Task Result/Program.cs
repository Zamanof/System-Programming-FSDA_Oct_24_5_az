// 
Task<int> task = Task.Run(() => TaskReturnMethod("Task 1", 3));

var result = task.Result;

Console.WriteLine(result);



int TaskReturnMethod(string name, int second)
{
    Console.WriteLine($@"
Name:               {name}
Thread Id:          {Thread.CurrentThread.ManagedThreadId}
IsBackground:       {Thread.CurrentThread.IsBackground}
IsThreadPool:       {Thread.CurrentThread.IsThreadPoolThread}
");

    Thread.Sleep(TimeSpan.FromSeconds(second));
    return second * 10;
}