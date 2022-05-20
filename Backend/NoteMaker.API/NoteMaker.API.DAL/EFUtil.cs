using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NoteMaker.API.Model;
using System.Linq;

namespace NoteMaker.API.DAL
{
    public class EFUtil
    {
        public void InsertRecord(NoteModel note)
        {
            using (var context = new NoteContext())
            {
                context.Notes.Add(note);
                context.SaveChanges();
            }
        }
        public NoteModel GetRecordById(int id)
        {
            using (var context = new NoteContext())
            {
                NoteModel note = (from n in context.Notes
                                  where n.ID == id
                                  select n).SingleOrDefault();
                return note;
            }
        }
        public List<NoteModel> GetAllRecords()
        {
            using (var context = new NoteContext())
            {
                List<NoteModel> notes = (from n in context.Notes
                                        select n).ToList();
                return notes;
            }
        }
        public void UpdateRecord(int id, NoteModel updatedNote)
        {
            using (var context = new NoteContext())
            {
                NoteModel noteToBeUpdated = (from n in context.Notes
                                             where n.ID == id
                                             select n).SingleOrDefault();
                if (noteToBeUpdated != null)
                {
                    noteToBeUpdated.NoteTitle = updatedNote.NoteTitle;
                    noteToBeUpdated.NoteContent = updatedNote.NoteContent;
                    noteToBeUpdated.ModifiedTime = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }
        public void DeleteRecord(int id)
        {
            using (var context = new NoteContext())
            {
                NoteModel noteToBeDeleted = (from n in context.Notes
                                             where n.ID == id
                                             select n).SingleOrDefault();
                if (noteToBeDeleted != null)
                {
                    context.Notes.Remove(noteToBeDeleted);
                    context.SaveChanges();
                }
            }
        }
    }
}
