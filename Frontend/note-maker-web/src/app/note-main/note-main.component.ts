import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { DataTransferService } from '../data-transfer.service';

@Component({
  selector: 'app-note-main',
  templateUrl: './note-main.component.html',
  styleUrls: ['./note-main.component.css']
})
export class NoteMainComponent implements OnInit {

  public notes: any[] = [
    {'NoteTitle': 'Sesha Notes 1', 'NoteContent': 'Test written by Sesha1 with dummy notes', 'Starred': false},
    {'NoteTitle': 'Sesha Notes 2', 'NoteContent': 'Test written by Sesha2 with dummy notes', 'Starred': false},
    {'NoteTitle': 'Sesha Notes 3', 'NoteContent': 'Test written by Sesha3 with dummy notes', 'Starred': false},
    {'NoteTitle': 'Sesha Notes 4', 'NoteContent': 'Test written by Sesha4 with dummy notes', 'Starred': false},
    {'NoteTitle': 'Sesha Notes 5', 'NoteContent': 'Test written by Sesha5 with dummy notes', 'Starred': false},
    {'NoteTitle': 'Sesha Notes 6', 'NoteContent': 'Test written by Sesha6 with dummy notes', 'Starred': false}
  ];
  public iconNames: Array<string> = new Array<string>();
  constructor(private router: Router, private dataService: DataTransferService) { 
    for(let i=0; i<this.notes.length; i++)
      this.iconNames[i] = 'star_border';
  }

  ngOnInit(): void {
  }
  public changeIcon(noteNumber: number): void {
    this.notes[noteNumber]['Starred'] = !this.notes[noteNumber]['Starred'];
    if(this.notes[noteNumber]['Starred'])
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

}
