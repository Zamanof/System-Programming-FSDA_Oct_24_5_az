using System;
using System.Diagnostics;
// Processes


//Process.Start("calc");
//Process.Start("mspaint");
//Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe");

//Console.WriteLine(Process.GetCurrentProcess().ProcessName);
//Console.WriteLine(Process.GetCurrentProcess().Id);
//Console.WriteLine(Process.GetCurrentProcess().BasePriority);
//Console.ReadLine();

var processes = Process.GetProcesses();

foreach (var process in processes)
{
    Console.WriteLine($"{process.Id}. {process.ProcessName} -> Threads: {process.Threads.Count}");
    process.Kill();
}

//var calc = Process.GetProcessById(30384); 
// Process Id OS terefinden dinamik olaraq teyin edilir ve her defe ferqli ola biler 

//calc.Kill();

//var calulators = Process.GetProcessesByName("CalculatorApp");
//var count = 0;
//foreach (var process in calulators)
//{
//    count++;
//    Console.WriteLine($"{process.Id}. {process.ProcessName} -> Threads: {process.Threads.Count}");
//    process.Kill();
//}

//Console.WriteLine(count);