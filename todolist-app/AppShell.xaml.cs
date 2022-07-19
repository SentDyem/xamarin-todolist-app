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
            Routing.RegisterRoute(nameof(TaskInfo), typeof(TaskInfo));
        }
}
}