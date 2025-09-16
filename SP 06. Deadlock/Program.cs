// Deadlock

object obj1 = new();
object obj2 = new();


Thread thread1 = new Thread(ObliviousMethod);
Thread thread2 = new Thread(BlindMethod);

thread1.Start();
thread2.Start();

void ObliviousMethod(object? obj)
{
    Console.WriteLine("ObliviousMethod start...");
	lock (obj1)
	{
        Thread.Sleep(1000);
		lock (obj2)
		{

		}
	}
    Console.WriteLine("ObliviousMethod end...");
}


void BlindMethod(object? obj)
{
    Console.WriteLine("BlindMethod start...");
    lock (obj2)
    {
        Thread.Sleep(1000);
        lock (obj1)
        {

        }
    }
    Console.WriteLine("BlindMethod end...");
}