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
        };

        Application.Run(myForm);
    }
    private static MyGame.Game? game;
    private static void MainScreen(Form1 myForm)
    {
        game = new MyGame.Game(myForm);
        // game.Setup();

        game.Play();
    }
}
//Application.Run(myForm);