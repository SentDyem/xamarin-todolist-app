using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todolist_app.Models;
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
            await Shell.Current.GoToAsync(nameof(TaskInfo));
        }

        private async void OnSelectionChanged(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                Note note = (Note)e.Item as Note;
                await Shell.Current.GoToAsync($"{nameof(TaskInfo)}?{nameof(TaskInfo.ItemId)}={note.Id.ToString()}");
            }
        }

        protected override async void OnAppearing()
        {
            notesList.ItemsSource = await App.NoteService.GetNotesAsync();
                base.OnAppearing();
        }
    }
}
