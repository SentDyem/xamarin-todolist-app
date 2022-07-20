using Plugin.LocalNotification;
using System;
using System.IO;
using todolist_app.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace todolist_app
{
    public partial class App : Application
    {
        static NoteService noteService;

        public static NoteService NoteService
        {
            get
            {
                if (noteService == null)
                {
                    noteService = new NoteService(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "NotesDB"));
                }
                return noteService;
            }
        }
        public App()
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

            MainPage = new AppShell();
 
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
