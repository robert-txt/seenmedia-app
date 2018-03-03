using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SeenMedia.Model
{
    public class SeenMediaEntry
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public string Media { get; set; }
        public DateTime Date { get; set; }
    }
}
