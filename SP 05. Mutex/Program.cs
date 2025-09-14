// Mutex -> Mutual Exclusion

#region internal thread
//Mutex mutex = new();

//int number = 1;

//for (int i = 0; i < 5; i++)
//{
//    Thread thread = new(Count);
//    thread.Name = $"Cenab Thread {i + 1}";
//    thread.Start();
//}

//void Count(object? obj)
//{
//    mutex.WaitOne();
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name}: {number++}");
//    }
//    mutex.ReleaseMutex();
//}

#endregion


#region Mutex external (global) threads
string mutexName = "minamyot";
using(Mutex mutex = new(true, mutexName))
{
    if (!mutex.WaitOne(30000))
    {
        Console.WriteLine($"Other instance running...");
        Thread.Sleep(1000);
        return;
    }
    else
    {
        Console.WriteLine("My code running...");
        Console.ReadKey();
        mutex.ReleaseMutex();
    }
}
#endregion
