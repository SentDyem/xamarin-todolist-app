﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todolist_app.Models;
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
            await Navigation.PushAsync(new MainPage());
        }

        private void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            if 
        }

        private void OnDeleteButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}