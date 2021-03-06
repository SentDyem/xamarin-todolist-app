using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todolist_app.Models;
using todolist_app.Views;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace todolist_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new Note();

        }

        private async void phonesList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new TaskInfo());

        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(TaskInfo));
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Note note = (Note)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(TaskInfo)}?{nameof(TaskInfo.ItemId)}={note.Id.ToString()}");
            }
        }

        protected override async void OnAppearing()
        {
            bool completed = false;
            allNotesList.ItemsSource = await App.NoteService.GetNotesAsync();
            activeNotesList.ItemsSource = await App.NoteService.GetGroupNotesAsync(completed = false);
            completedNotesList.ItemsSource = await App.NoteService.GetGroupNotesAsync(completed = true);
            base.OnAppearing();
        }

        private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            
            var checkbox = (CheckBox)sender;
            var selectedNote = BindingContext as Note;
            selectedNote.Completed = e.Value;
            await App.NoteService.SaveNoteAsync(selectedNote);

        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            allNotesList.ItemsSource = await App.NoteService.GetNotesSearchAsync(e.NewTextValue);
            tabView.SelectedIndex = 0;

        }

        private async void OpenPooupButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Информация о приложении", "Деловик ver. 0.2", "OK");
        }
    }
}
