using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace Toastundmehr
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer dp = new DispatcherTimer();

        public MainPage()
        {
            this.InitializeComponent();
            dp.Interval = new TimeSpan(0, 0, 5);
            dp.Tick += Dp_Tick;
            dp.Start();
        }
        private void Dp_Tick(object sender, object e)
        {
            string mytoast = $@"<toast>
<visual branding='logo'>
<binding template='ToastGeneric'>
<text>Hallo Toast</text>
<text>ich bins</text>
<image src='Assets/Square44x44Logo.scale-200.png'/>
<image src='Assets/Square44x44Logo.scale-200.png' placement='appLogoOverride' hint-crop='circle'/>
</binding>
</visual>
</toast>
";
            var toastXml = new XmlDocument();
            toastXml.LoadXml(mytoast);
            var toast = new ToastNotification(toastXml);
                toast.Failed += Toast_Failed;
            toast.Activated += Toast_Activated;
            toast.SuppressPopup = true;
            //Windows.ApplicationModel.Package.Current.Id.Name
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        private void Toast_Activated(ToastNotification sender, object args)
        {
        }

        private void Toast_Failed(ToastNotification sender, ToastFailedEventArgs args)
        {

          }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mytoast = $@"<toast>
<visual branding='logo'>
<binding template='ToastGeneric'>
<text>Hallo Toast</text>
<text>ich bins</text>
<image src='Assets/Square44x44Logo.scale-200.png'/>
<image src='Assets/Square44x44Logo.scale-200.png' placement='appLogoOverride' hint-crop='circle'/>
</binding>
</visual>
</toast>
";

            //string title = "The current time is";
            //string timeString = $"{DateTime.Now:HH:mm:ss}";
            //string thomasImage = "https://www.thomasclaudiushuber.com/thomas.jpg";

            //string toastXmlString =
            //$@"<toast><visual>
            //        <binding template='ToastGeneric'>
            //        <text>{title}</text>
            //        <text>{timeString}</text>
            //        <image src='{thomasImage}'/>
            //        </binding>
       //         </visual></toast>";

            var toastXml = new XmlDocument();
            toastXml.LoadXml(mytoast);
            var toast = new ToastNotification(toastXml);
            toast.SuppressPopup = false;

            var t = ToastNotificationManager.CreateToastNotifier();
            t.Show(toast);
        }

    }
}
