using System;
using Windows.UI.Notifications;

namespace CoreToastConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var template = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);

            var textNodes = template.GetElementsByTagName("text");
            textNodes.Item(0).InnerText = "Hello worlds";

            var notifier = ToastNotificationManager.CreateToastNotifier(@"{1AC14E77-02E7-4E5D-B744-2EB1AE5198B7}\WindowsPowerShell\v1.0\powershell.exe");
            var notification = new ToastNotification(template);
            notifier.Show(notification);

        }
    }
}
