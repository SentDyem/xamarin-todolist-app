using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todolist_app.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace todolist_app.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class TaskInfo : ContentPage
{
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }

        public TaskInfo()
    {
        InitializeComponent();

            BindingContext = new Note();
            timeOfDate.MinimumDate = DateTime.UtcNow;
    }

        private async void LoadNote(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);
                Note note = await App.NoteService.GetNoteAsync(id);
                BindingContext = note;
            }
            catch { }
        }

        private async void DownButton_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
            if (!string.IsNullOrWhiteSpace(note.Content))
            {
                bool result = await DisplayAlert("Подтвердить действие", "Вы не сохранили изменения. Уверены, что хотите выйти?", "Да", "Нет");
                if (result == true)
                {
                    await Navigation.PushAsync(new MainPage());
                }
                
            }
            else
            {
                await Navigation.PushAsync(new MainPage());
            }
          
 
        }

        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
          note.Date = timeOfDate.Date + timeOfDay.Time;
            //note.Completed = false;
            if (!string.IsNullOrWhiteSpace(note.Content))
            {
                await App.NoteService.SaveNoteAsync(note);
            }
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
            await App.NoteService.DeleteNoteAsync(note);
            await Shell.Current.GoToAsync("..");
        }

        private async void ShareButton_ClickedAsync(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
                {
                Title = "Приглашаю в Деловик.",
                Text = "Привет! Недавно начал использовать новый планировщик дел под названием 'Деловик'.Скорее присоединяйся"
            });
        }
    }
}