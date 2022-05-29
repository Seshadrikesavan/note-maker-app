import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {ToastrService} from 'ngx-toastr';
import { DataTransferService } from '../data-transfer.service';

@Component({
  selector: 'app-edit-note',
  templateUrl: './edit-note.component.html',
  styleUrls: ['./edit-note.component.css']
})
export class EditNoteComponent implements OnInit {

  constructor(private toastrService: ToastrService, private dataService: DataTransferService) {
    
  }
  subscriber: any
  noteToEdit: any;

  addNoteGroup: FormGroup = new FormGroup({
      title: new FormControl('', [Validators.required, Validators.minLength(1)]),
      content: new FormControl('', [Validators.required, Validators.minLength(1)])
  });

  ngOnInit(): void {
    this.subscriber = this.dataService.fetchMessage();
    this.subscriber.subscribe((data: any) => this.noteToEdit = data);
    console.log(this.noteToEdit);
    this.addNoteGroup.setValue({
      'title': this.noteToEdit['NoteTitle'],
      'content': this.noteToEdit['NoteContent']
    });
  }
  ngOnDestroy(): void {
    //this.subscriber.unsubscribe();
  }

  onSubmit(): void {
      if(this.addNoteGroup.valid)
      {
        this.toastrService.success("Note saved successfully", "Success");
      }
  }

}
