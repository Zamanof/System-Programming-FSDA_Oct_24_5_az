namespace SP_02._Threads_in_UI_app;

public partial class Form1 : Form
{
    static int count = 0;
    public Form1()
    {
        InitializeComponent();
        timer1.Tick += counter;
    }

    private void counter(object sender, EventArgs args)
    {
        countLabel.Text = count.ToString();
        count++;
    }
    private void startButton_Click(object sender, EventArgs e)
    {
        //Thread thread = new Thread(() =>
        //{
        //    startButton.Enabled = false;
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        Thread.Sleep(1000);
        //        //countLabel.Text = i.ToString();
        //    }
        //    startButton.Enabled = true;
        //});
        //thread.IsBackground = true;
        //thread.Start();
        timer1.Start();
    }
}
