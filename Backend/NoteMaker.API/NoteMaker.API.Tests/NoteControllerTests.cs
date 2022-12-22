using System;
using NoteMaker.API.Controllers;
using NoteMaker.API.Service;
using NoteMaker.API.Model;
using NoteMaker.API.Controllers.Notes;
using NUnit;
using NUnit.Framework;
using Moq;
using NoteMaker.API.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NoteMaker.API.Tests
{
    [TestFixture]
    public class NoteControllerTests
    {
        NoteController controller;
        Mock<INoteService> noteServiceMock;
        public NoteControllerTests()
        { 

        }

        [SetUp]
        public void Setup() 
        {
            noteServiceMock = new Mock<INoteService>();
            controller = new NoteController(noteServiceMock.Object);
        }
        [Test]
        public void CreateNoteShouldReturnCreatedOnSuccess()
        {
            NoteModel note = new NoteModel()
            {
                NoteTitle = "Test",
                NoteContent = "Test Content",
            };
            var result = (ObjectResult)controller.CreateNote(note);
            Assert.IsNotNull(result);
            Assert.AreEqual(201, result.StatusCode);
        }

        [Test]
        public void GetNoteByIDShouldReturnValidNote()
        {
            noteServiceMock.Setup(m => m.GetNoteById(1)).Returns(new NoteModel()
            {
                NoteTitle = "Test",
                NoteContent = "Test Content",
            });
            var result = (ObjectResult)controller.GetNoteById(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsInstanceOf<NoteModel>(result.Value);
        }
        [Test]
        public void GetNoteByIDShouldReturnEmptyResultForInvalidNoteID()
        {
            noteServiceMock.Setup(m => m.GetNoteById(0)).Returns(null as NoteModel);
            var result = (ObjectResult)controller.GetNoteById(0);
            Assert.IsNotNull(result);
            Assert.AreEqual(204, result.StatusCode);
        }
        [Test]
        public void GetAllNotesShouldReturnValidNoteList()
        {
            noteServiceMock.Setup(m => m.GetAllNotes()).Returns(new List<NoteModel>() 
            {   
                new NoteModel() 
                {
                    NoteTitle = "Test",
                    NoteContent= "Test Content"
                }
            });
            var result = (ObjectResult)controller.GetAllNotes();
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsInstanceOf<List<NoteModel>>(result.Value);
        }
        [Test]
        public void GetAllNotesShouldReturnEmptyResultWhenNoteListIsEmpty()
        {
            noteServiceMock.Setup(m => m.GetAllNotes()).Returns(new List<NoteModel>());
            var result = (ObjectResult)controller.GetAllNotes();
            Assert.IsNotNull(result);
            Assert.AreEqual(204, result.StatusCode);
        }
        [Test]
        public void UpdateNoteShouldReturnCreatedOnSuccess()
        {
            NoteModel note = new NoteModel()
            {
                NoteTitle = "Test",
                NoteContent = "Test Updated Content",
            };
            var result = (ObjectResult)controller.UpdateNote(1, note);
            Assert.IsNotNull(result);
            Assert.AreEqual(201, result.StatusCode);
        }
        [Test]
        public void DeleteNoteShouldReturnOKOnSuccess()
        {
            var result = (ObjectResult)controller.DeleteNote(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        [TearDown]
        public void Teardown() 
        {
            controller = null;
        }

    }
}
