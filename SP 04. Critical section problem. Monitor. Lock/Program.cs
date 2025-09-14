
#region Albahari tricks
// First trick
//for (int i = 0; i < 10; i++)
//{
//    new Thread(() =>
//    {
//        Console.WriteLine(i);
//    }).Start();
//}

// solve first trick
//for (int i = 0; i < 10; i++)
//{
//    int a = i;
//    new Thread(() =>
//    {
//        Console.WriteLine(a);
//    }).Start();
//}

// Second trick
//string name = "Nadir";
//Thread thread1 = new(() => 
//{ 
//    Console.WriteLine(name); 
//});

//name = "Zaman";

//Thread thread2 = new(() => 
//{ 
//    Console.WriteLine(name); 
//});
//thread2.Start();
//thread1.Start();

#endregion

// Critical section - Thread-lerin eyni bir
// yaddash sahesini(resursu) paylashmasi

#region Critical section problem
//Thread[] threads = new Thread[5];

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int i = 0; i < 1000000; i++)
//        {
//            Counter.count++;
//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine($"Count = {Counter.count}");

#endregion

#region Interlocked
//Thread[] threads = new Thread[5];

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int i = 0; i < 1000000; i++)
//        {
//            Interlocked.Increment(ref Counter.count);
//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine($"Count = {Counter.count}");

#endregion

#region Interlocked problem
//Thread[] threads = new Thread[5];

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int i = 0; i < 1000000; i++)
//        {
//            Interlocked.Increment(ref Counter.count);

//            if (Counter.count % 2 == 0)
//                Interlocked.Increment(ref Counter.even);
//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine($"Count = {Counter.count}");
//Console.WriteLine($"Count = {Counter.even}");

#endregion

#region Monitor
//Thread[] threads = new Thread[5];
//object o = new();
//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int i = 0; i < 1000000; i++)
//        {
//            try
//            {
//                Monitor.Enter(o);

//                Counter.count++;

//                if (Counter.count % 2 == 0) Counter.even++;
//            }
//            finally
//            {
//                Monitor.Exit(o);
//            }


//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine($"Count = {Counter.count}");
//Console.WriteLine($"Count = {Counter.even}");

#endregion

#region Monitor
//Thread[] threads = new Thread[5];
//object o = new();
//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int i = 0; i < 1000000; i++)
//        {
//            // lock -> Monitor syntax sugar
//            lock (o)
//            {
//                Counter.count++;
//                if (Counter.count % 2 == 0) Counter.even++;
//            }
//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine($"Count = {Counter.count}");
//Console.WriteLine($"Count = {Counter.even}");

#endregion