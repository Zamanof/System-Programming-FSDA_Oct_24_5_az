// Semaphore VS SemaphoreSlim

#region Semaphore internal
//Semaphore semaphore = new(3, 3);
//for (int i = 0; i < 30; i++)
//{
//    ThreadPool.QueueUserWorkItem(Some, semaphore);
//}
//Console.ReadKey();
//void Some(object? state)
//{
//    Random random = new();
//    var s = state as Semaphore;
//    bool st = false;

//    while (!st)
//    {
//        if (s.WaitOne(500))
//        {
//            try
//            {
//                Thread.Sleep(1);
//                Console.WriteLine($"Cenab {Thread.CurrentThread.ManagedThreadId} take key");
//                Thread.Sleep(random.Next(1000, 5000));
//            }
//            finally
//            {
//                Thread.Sleep(1);
//                st = true;
//                Console.WriteLine($"    Cenab {Thread.CurrentThread.ManagedThreadId} return key");
//                s.Release();
//            }
//        }
//        else
//        {
//            Thread.Sleep(1);
//            Console.WriteLine($"        Cenab {Thread.CurrentThread.ManagedThreadId} sorry no keys yet");
//        }

//    }
//}

#endregion

#region Semaphore external
//Semaphore semaphore = new(3, 3, "Simovar");
//for (int i = 0; i < 30; i++)
//{
//    ThreadPool.QueueUserWorkItem(Some, semaphore);
//}
//Console.ReadKey();
//void Some(object? state)
//{
//    Random random = new();
//    var s = state as Semaphore;
//    bool st = false;

//    while (!st)
//    {
//        if (s.WaitOne(500))
//        {
//            try
//            {
//                Thread.Sleep(1);
//                Console.WriteLine($"Cenab {Thread.CurrentThread.ManagedThreadId} take key");
//                Thread.Sleep(random.Next(1000, 5000));
//            }
//            finally
//            {
//                Thread.Sleep(1);
//                st = true;
//                Console.WriteLine($"    Cenab {Thread.CurrentThread.ManagedThreadId} return key");
//                s.Release();
//            }
//        }
//        else
//        {
//            Thread.Sleep(1);
//            Console.WriteLine($"        Cenab {Thread.CurrentThread.ManagedThreadId} sorry no keys yet");
//        }

//    }
//}

#endregion

#region Semaphore external
SemaphoreSlim semaphore = new(3, 3);
for (int i = 0; i < 30; i++)
{
    ThreadPool.QueueUserWorkItem(Some, semaphore);
}
Console.ReadKey();
void Some(object? state)
{
    Random random = new();
    var s = state as SemaphoreSlim;
    bool st = false;

    while (!st)
    {
        if (s.Wait(500))
        {
            try
            {
                Thread.Sleep(1);
                Console.WriteLine($"Cenab {Thread.CurrentThread.ManagedThreadId} take key");
                Thread.Sleep(random.Next(1000, 5000));
            }
            finally
            {
                Thread.Sleep(1);
                st = true;
                Console.WriteLine($"    Cenab {Thread.CurrentThread.ManagedThreadId} return key");
                s.Release();
            }
        }
        else
        {
            Thread.Sleep(1);
            Console.WriteLine($"        Cenab {Thread.CurrentThread.ManagedThreadId} sorry no keys yet");
        }

    }
}

#endregion