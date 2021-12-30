using System.Diagnostics;

namespace CS_MyConsole
{
    class MyStopwatch
    {
        private static Stopwatch stopWatch = new Stopwatch();
        public static string Measure(Action action)
        {
            stopWatch.Start();

            action.Invoke();

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = ts.Milliseconds.ToString();

            stopWatch.Reset();

            return ("RunTime " + elapsedTime);
        }
    }
}