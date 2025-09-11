// Threads
//Console.WriteLine($"Main Thread Id: {Thread.CurrentThread.ManagedThreadId}");
//Console.WriteLine($"Main Thread IsBackground: {Thread.CurrentThread.IsBackground}");

Console.WriteLine("Start");
Thread thread1 = new Thread(() =>
{
    //int summ = 0;
    for (int i = 0; i < 1000; i++)
    {
        Thread.Sleep(1);
        //summ += i;
        Console.WriteLine($"\tFirst Thread Id: {Thread.CurrentThread.ManagedThreadId} - {i} - IsBackground: {Thread.CurrentThread.IsBackground}");
    }
    //Console.WriteLine($"First thread result - {summ}");
});

Thread thread2 = new Thread(Some);

//thread1.Priority = ThreadPriority.Highest;
//thread2.Priority = ThreadPriority.Lowest;


//thread1.IsBackground = true;
//thread2.IsBackground = true;

//thread1.Start();
//thread2.Start();

//thread2.Join();
//int summ = 0;
//for (int i = 0; i < 100; i++)
//{
//    //summ += i;
//    Console.WriteLine($"Main method Thread Id: {Thread.CurrentThread.ManagedThreadId} - {i} - IsBackground: {Thread.CurrentThread.IsBackground}");
//}
//Console.WriteLine($"Main thread result - {summ}");

//thread1.Join();// Chaqiran thread-i chaqirilan thread-i gozlemeye mecbur edir

//Console.ReadLine();

//ConsoleKeyInfo key = default;

//key = Console.ReadKey();
//if (key.Key == ConsoleKey.Enter)
//{
//    thread1.Interrupt();
//}




//Console.WriteLine("End");
void Some()
{
    //int summ = 0;
    for (int i = 0; i < 100; i++)
    {
        //summ += i;
        Console.WriteLine($"\t\tSome method Thread Id: {Thread.CurrentThread.ManagedThreadId} - {i} - IsBackground: {Thread.CurrentThread.IsBackground}");
    }
    //Console.WriteLine($"Some thread result - {summ}");
}