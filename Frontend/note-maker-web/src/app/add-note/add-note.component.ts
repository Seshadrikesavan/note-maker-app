import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {ToastrService} from 'ngx-toastr';
import { ApiService } from '../api.service';
import { NoteModel } from 'src/models/NoteModel';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.css']
})
export class AddNoteComponent implements OnInit {

  constructor(private toastrService: ToastrService, private apiService: ApiService) { }

  public isFormValid: boolean = false;
  public noteTitle: string;
  public noteContent: string;

  addNoteGroup: FormGroup = new FormGroup({
      title: new FormControl('', [Validators.required, Validators.minLength(1)]),
      content: new FormControl('', [Validators.required, Validators.minLength(1)])
  });

  ngOnInit(): void {
  }

  onSubmit(): void {
      if(this.addNoteGroup.valid)
      {
        let note: NoteModel = new NoteModel({
          noteTitle: this.noteTitle ?? '',
          noteContent: this.noteContent ?? ''
        });
        this.apiService.addNote(note).subscribe();
        this.toastrService.success("Note saved successfully", "Success");
      }
  }
}
