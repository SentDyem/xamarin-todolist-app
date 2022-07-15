using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace todolist_app.Models
{
    class Task
{
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Note { get; set; }

        public DateTime Time { get; set; }
}
