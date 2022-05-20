using System;
using System.Collections.Generic;
using System.Text;
using NoteMaker.API.Model;

namespace NoteMaker.API.Service.Interfaces
{
    public interface INoteService
    {
        public void CreateNote(NoteModel noteModel);
        public NoteModel GetNoteById(int id);
        public List<NoteModel> GetAllNotes();
        public void UpdateNote(int id, NoteModel updatedNote);
        public void DeleteNote(int id);
    }
}
