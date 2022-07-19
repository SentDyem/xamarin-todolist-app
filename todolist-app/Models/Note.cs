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

        public DateTime Date { get; set; }

        public Boolean Completed { get; set; }
    }
}
