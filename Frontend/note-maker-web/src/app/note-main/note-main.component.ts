import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { DataTransferService } from '../data-transfer.service';
import { ApiService } from '../api.service';
import { NoteModel } from 'src/models/NoteModel';
import { ModifiedPipe } from '../modified.pipe';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-note-main',
  templateUrl: './note-main.component.html',
  styleUrls: ['./note-main.component.css']
})
export class NoteMainComponent implements OnInit {

  public notes: NoteModel[] = [] /* = [
    {'NoteTitle': 'Sesha Notes 1', 'NoteContent': 'Test written by Sesha1 with dummy notes', 'Starred': false},
    {'NoteTitle': 'Sesha Notes 2', 'NoteContent': 'Test written by Sesha2 with dummy notes', 'Starred': false},
    {'NoteTitle': 'Sesha Notes 3', 'NoteContent': 'Test written by Sesha3 with dummy notes', 'Starred': false},
    {'NoteTitle': 'Sesha Notes 4', 'NoteContent': 'Test written by Sesha4 with dummy notes', 'Starred': false},
    {'NoteTitle': 'Sesha Notes 5', 'NoteContent': 'Test written by Sesha5 with dummy notes', 'Starred': false},
    {'NoteTitle': 'Sesha Notes 6', 'NoteContent': 'Test written by Sesha6 with dummy notes', 'Starred': false}
  ] */;
  public iconNames: string[] = [];

  constructor(private router: Router, private dataService: DataTransferService, private apiService: ApiService, private tostrService: ToastrService) {
    
  }

  ngOnInit(): void {
    this.loadAllNotes();
  }
  public loadAllNotes()
  {
    this.apiService.getAllNotes().subscribe((data: NoteModel[]) =>{
      console.log(data);
      for(let i=0; i<data.length; i++)
      {
        if(data[i].starred)
          this.iconNames[i] = 'star';
        else
          this.iconNames[i] = 'star_border';
        this.notes.push(data[i]);
      }
   }); 
   console.log(this.notes);
  }
  public changeIcon(noteNumber: number): void {
    this.notes[noteNumber].starred = !this.notes[noteNumber].starred;
    this.apiService.editNote(this.notes[noteNumber]).subscribe();
    if(this.notes[noteNumber].starred)
      this.iconNames[noteNumber] = 'star';
    else
      this.iconNames[noteNumber] = 'star_border';
  }
  public SendCurrentNote(note: any, i: number)
  {
    console.log(note);
    this.dataService.sendMessage(note);
    this.router.navigate(['/edit-note', i]);
  }

  public DeleteNote(noteId: number)
  {
    this.apiService.deleteNote(noteId).subscribe();
    this.tostrService.success('Note Deleted successfully');
    this.notes = this.notes.filter(id => id.id != noteId);
  }

}
