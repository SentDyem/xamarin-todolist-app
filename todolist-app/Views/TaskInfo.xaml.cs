using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace todolist_app.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class TaskInfo : ContentPage
{
    public TaskInfo()
    {
        InitializeComponent();
    }

        private async void DownButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}