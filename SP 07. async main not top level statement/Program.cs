using System;
using System.Net;

namespace SP_07._async_main_not_top_level_statement;

internal class Program
{
    static async Task Main(string[] args)
    {
        WebClient webClient = new();
        string url = @"https://www.youtube.com/";
        Console.WriteLine(await webClient.DownloadStringTaskAsync(url));
    }
}
