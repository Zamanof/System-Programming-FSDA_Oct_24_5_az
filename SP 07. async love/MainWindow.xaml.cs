using System.Net;
using System.Windows;

namespace SP_07._async_love;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    WebClient webClient = new();
    string url = @"https://www.youtube.com/";

    public MainWindow()
    {
        InitializeComponent();
    }

    private void SimpleDownload(object sender, RoutedEventArgs e)
    {
        var text = webClient.DownloadString(url);
        Thread.Sleep(5000);
        contentTextBox.Text = text;
    }
    private void DontClick(object sender, RoutedEventArgs e)
    {
        var task = webClient.DownloadStringTaskAsync(url);
        contentTextBox.Text = task.Result;
    }
    private void TaskDownload(object sender, RoutedEventArgs e)
    {
        var task = webClient.DownloadStringTaskAsync(url)
            .ContinueWith(t =>
            {
                //Thread.Sleep(3000);
                //contentTextBox.Text = t.Result;
            }, TaskScheduler.FromCurrentSynchronizationContext());
    }
    private void TaskContextDownload(object sender, RoutedEventArgs e)
    {
        var context = SynchronizationContext.Current;
        var task = webClient.DownloadStringTaskAsync(url)
            .ContinueWith(t =>
            {
                Thread.Sleep(3000);
                context!.Send(_ =>
                {
                    contentTextBox.Text = t.Result;
                },null);
            });
    }
    private async void DownloadAsync(object sender, RoutedEventArgs e)
    {
        var result = await webClient.DownloadStringTaskAsync(url);
        contentTextBox.Text = result;
    }

    private void Clear(object sender, RoutedEventArgs e)
    {
        contentTextBox.Clear();
    }
}