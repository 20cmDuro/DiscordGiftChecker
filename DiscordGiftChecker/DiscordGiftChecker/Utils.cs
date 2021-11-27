using System.Windows.Threading;

namespace DiscordGiftChecker
{
    internal class Utils
    {
        public static void Sleep(int ms, Action action)
        {
            var timer = new DispatcherTimer();
            timer.Tick += delegate

            {
                action.Invoke();
                timer.Stop();
            };

            timer.Interval = TimeSpan.FromMilliseconds(ms);
            timer.Start();
        }
    }
}
