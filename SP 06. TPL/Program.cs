// TPL - Task Parallel Library

// Thread -> ThreadPool -> Task

Task task1 = new Task(() =>
{
    TaskMethod("Task 1");
});

Task task2 = new Task(() =>
{
    TaskMethod("Task 2");
});

Task task3 = Task.Run(() =>
{
    TaskMethod("Task 3");
});


Task task4 = Task.Factory.StartNew(() =>
{
    TaskMethod("Task 4");
});

Task task5 = new Task(() =>
{
    TaskMethod("Task 5");
}, TaskCreationOptions.LongRunning);

task1.Start();
task2.Start();
task5.Start();

task1.Wait();
task2.Wait();
task3.Wait();
task4.Wait();
task5.Wait();

void TaskMethod(string name)
{
    Console.WriteLine($@"
Name:               {name}
Thread Id:          {Thread.CurrentThread.ManagedThreadId}
IsBackground:       {Thread.CurrentThread.IsBackground}
IsThreadPool:       {Thread.CurrentThread.IsThreadPoolThread}
");
}
