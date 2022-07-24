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
        public readonly SQLiteAsyncConnection db;

        public NoteService(string connectionString)
        {
            db = new SQLiteAsyncConnection(connectionString);
            db.CreateTableAsync<Note>().Wait();

        }
        public async Task<List<Note>> GetNotesAsync()
        {
            return await db.Table<Note>().ToListAsync();
        }

        public async Task<Note> GetNoteAsync(int id)
        {
            return await db.Table<Note>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Note>> GetNotesSearchAsync(string textValue)
        {
            return await db.Table<Note>().Where(i => i.Content.StartsWith(textValue)).ToListAsync();
        }

        public async Task<List<Note>> GetActiveNotesAsync()
        {
            return await db.Table<Note>().Where(i => i.Completed == false).ToListAsync();
        }

        public async Task <int> CountActiveNotesAsync()
        {
             return await db.Table<Note>().Where(i => i.Completed == false).CountAsync();   
        }

        public async Task<List<Note>> GetCompletedNotesAsync()
        {
            return await db.Table<Note>().Where(i => i.Completed == true).ToListAsync();
        }

        public async Task<int> SaveNoteAsync(Note note)
        {
            if (note.Id != 0)
            {
                return await db.UpdateAsync(note);
            }
            else
            {
                return await db.InsertAsync(note);
            }
        }

        public async Task<int> DeleteNoteAsync(Note note)
        {
            return await db.DeleteAsync(note);
        }
    }
}
