using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoteMaker.API.Model;
using NoteMaker.API.Service.Interfaces;

namespace NoteMaker.API.Controllers.Notes
{
    [Route("api/notemaker")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost]
        [Route("note")]
        public IActionResult CreateNote([FromBody] NoteModel note)
        {
            try
            {
                if (note == null)
                    return StatusCode(400, "Invalid input");
                _noteService.CreateNote(note);
                return StatusCode(201, "Note Created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("note/{id}")]
        public IActionResult GetNoteById(int id)
        {
            try
            {
                NoteModel note = _noteService.GetNoteById(id);
                if (note != null)
                    return StatusCode(200, note);
                return StatusCode(204, "Note not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("notes")]
        public IActionResult GetAllNotes()
        {
            try
            {
                List<NoteModel> notes = _noteService.GetAllNotes();
                if (notes != null && notes.Count > 0)
                    return StatusCode(200, notes);
                return StatusCode(204, "No notes added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [Route("note/{id}")]
        public IActionResult UpdateNote(int id, [FromBody] NoteModel note)
        {
            try
            {
                if (note == null)
                    return StatusCode(400, "Invalid input");
                _noteService.UpdateNote(id, note);
                return StatusCode(201, "Note Updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Route("note/{id}")]
        public IActionResult DeleteNote(int id)
        {
            try
            {
                _noteService.DeleteNote(id);
                return StatusCode(200, "Note Deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
