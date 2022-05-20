using System;
using NoteMaker.API.Service.Interfaces;
using NoteMaker.API.Model;
using NoteMaker.API.DAL;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace NoteMaker.API.Service
{
    public class NoteService : INoteService
    {
        private EFUtil util = new EFUtil();
        private ILogger<NoteService> _logger;
        public NoteService(ILogger<NoteService> logger)
        {
            _logger = logger;
        }
        public void CreateNote(NoteModel noteModel)
        {
            try
            {
                util.InsertRecord(noteModel);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }
        public NoteModel GetNoteById(int id)
        {
            try
            {
                NoteModel note = util.GetRecordById(id);
                return note;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }
        public List<NoteModel> GetAllNotes()
        {
            try
            {
                List<NoteModel> notes = util.GetAllRecords();
                return notes;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }
        public void UpdateNote(int id, NoteModel updatedNote)
        {
            try
            {
                util.UpdateRecord(id, updatedNote);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }
        public void DeleteNote(int id)
        {
            try
            {
                util.DeleteRecord(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }
    }
}
