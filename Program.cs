using System.Diagnostics;
using System.Runtime.InteropServices;

namespace winform;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        Form1 myForm = new Form1();

        var screenThread = new Thread(() => MainScreen(myForm));

        myForm.Shown += (s, a) =>
        {
            screenThread.Start();
        };
        myForm.FormClosing += (s, a) =>
        {
            game?.Stop();
            screenThread.Join();
            ConsoleRunning = false;
        };

        myForm.Load += Form1Load;

        Application.Run(myForm);
    }

    private static void Form1Load(object? sender, EventArgs e)
    {
        AllocConsole();
    }

    private static MyGame.Game? game;
    private static void MainScreen(Form1 myForm)
    {
        game = new MyGame.Game(myForm);
        // game.Setup();

        var myConsole = new Thread(() => MyConsoleApp(game));

        myConsole.Start();

        game.Play();
    }
    private static bool ConsoleRunning = false;
    private static void MyConsoleApp(MyGame.Game game)
    {
        // Process commandProcess = new Process();
        // commandProcess.StartInfo.FileName = "cmd";
        // commandProcess.StartInfo.UseShellExecute = true;
        // commandProcess.Start();

        ConsoleRunning = true;
        while (ConsoleRunning)
        {
            Console.WriteLine("Ball amount: " + game.balls.Count());
            Console.WriteLine("Gravity: " + MyGame.BallPhysics.gravity);
            Console.WriteLine("Wind: " + MyGame.BallPhysics.wind);
            Thread.Sleep(100);
            Console.SetCursorPosition(0, 0);
        }
    }
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();
}
//Application.Run(myForm);