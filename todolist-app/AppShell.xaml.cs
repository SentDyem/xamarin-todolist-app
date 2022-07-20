using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var requestNotification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "Test",
                Title = "Деловик ",
                NotificationId = 1337,
                Schedule = {
                    NotifyTime = DateTime.Now.AddSeconds(10)
                }

            };
            NotificationCenter.Current.Show(requestNotification);
            Routing.RegisterRoute(nameof(TaskInfo), typeof(TaskInfo));
        }
}
}