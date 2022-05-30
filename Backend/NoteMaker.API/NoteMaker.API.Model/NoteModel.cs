using System;

namespace NoteMaker.API.Model
{
    public class NoteModel
    {
        public int ID { get; set; }
        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }
        public bool Starred { get; set; } = false;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime ModifiedTime { get; set; } = DateTime.Now;
    }
}
