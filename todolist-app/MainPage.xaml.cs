using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todolist_app.Views;
using Xamarin.Forms;

namespace todolist_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void phonesList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new TaskInfo());

        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskInfo());
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        protected override async void OnAppearing()
        {
            notesList.ItemsSource = await App.NoteService.GetNotesAsync();
                base.OnAppearing();
        }
    }
}
