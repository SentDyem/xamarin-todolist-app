using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using todolist_app.Models;
using Xamarin.Essentials;

namespace todolist_app.Services
{
    
     public class NoteService
{
        readonly SQLiteAsyncConnection db;

        public NoteService(string connectionString)
        {
            db = new SQLiteAsyncConnection(connectionString);
            db.CreateTableAsync<Note>().Wait();

        }
        public Task<List<Note>> GetNotesAsync()
        {
            return db.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return db.Table<Note>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Note>> GetNotesSearchAsync(string textValue)
        {
            return db.Table<Note>().Where(i => i.Content.StartsWith(textValue)).ToListAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.Id != 0)
            {
                return db.UpdateAsync(note);
            }
            else
            {
                return db.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return db.DeleteAsync(note);
        }
    }
}
