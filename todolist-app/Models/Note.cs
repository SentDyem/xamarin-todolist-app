using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace todolist_app.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Content { get; set; }

        DateTime actualDate = DateTime.UtcNow;
        public DateTime Date {
            get; set;
        }
        public bool Completed { get; set; }

    }
}
