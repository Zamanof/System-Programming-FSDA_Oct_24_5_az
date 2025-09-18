// See https://aka.ms/new-console-template for more information

using System.Net;

WebClient webClient = new();
string url = @"https://www.youtube.com/";

//SomeVoidAsync(url);
Console.WriteLine(await SomeReturnAsync(url));
Console.ReadLine();

async void SomeVoidAsync(string url)
{
    Console.WriteLine(await webClient.DownloadStringTaskAsync(url));
}

async Task<string> SomeReturnAsync(string url)
{
    return await webClient.DownloadStringTaskAsync(url);
}
