using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todolist_app.Services;
using todolist_app.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace todolist_app
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class AppShell : Shell
    {
        
        public AppShell()
    {
        InitializeComponent();

           NotificationCenter.Current.Show((notification) => notification
            .WithScheduleOptions((schedule) => schedule
                    .NotifyAt(DateTime.Now.AddSeconds(46000)) // Used for Scheduling local notification, if not specified notification will show immediately.
                    .Build())
                        .WithTitle("Активные задачи")
                        .WithDescription("Обнаружены активные задачи.")
                        .WithNotificationId(100)
                        .Create());

            Routing.RegisterRoute(nameof(TaskInfo), typeof(TaskInfo));
        }
}
}