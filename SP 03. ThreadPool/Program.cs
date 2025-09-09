// ThreadPool

/*
 CLR Thread Poll thread-lerini istifade edir:
1. ThreadPool class-i
2. WinForm timer
3. Asinxron metodlar (.BeginInvoke(), .EndInvoke()) -> kohnelib
*/

deleg deleg = SomeOperations;
deleg.BeginInvoke(null, null, null);

//ThreadPool.GetAvailableThreads(out int workerCount, out int complCount);

//Console.WriteLine(workerCount);
//Console.WriteLine(complCount);

Console.WriteLine("Main method start...");
//Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
//Console.WriteLine(Thread.CurrentThread.IsBackground);

ThreadPool.QueueUserWorkItem(SomeOperations!, "Salam");
ThreadPool.QueueUserWorkItem(o =>
{
    OtherOperations();
});

Console.WriteLine("Main method end...");
Console.ReadLine();


void SomeOperations(object state)
{
    Console.WriteLine(@$"
SomeOperations method start...
State:          {state}
ThreadId:       {Thread.CurrentThread.ManagedThreadId}
IsBackground:   {Thread.CurrentThread.IsBackground}
IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}

");
}

void OtherOperations()
{
    Console.WriteLine(@$"
OtherOperations method start...
ThreadId:       {Thread.CurrentThread.ManagedThreadId}
IsBackground:   {Thread.CurrentThread.IsBackground}
IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}

");
}

delegate void deleg(object a);