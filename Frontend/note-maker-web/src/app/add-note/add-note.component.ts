import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.css']
})
export class AddNoteComponent implements OnInit {

  constructor(private toastrService: ToastrService) { }

  public isFormValid: boolean = false;

  addNoteGroup: FormGroup = new FormGroup({
      title: new FormControl('', [Validators.required, Validators.minLength(1)]),
      content: new FormControl('', [Validators.required, Validators.minLength(1)])
  });

  ngOnInit(): void {
  }

  onSubmit(): void {
      if(this.addNoteGroup.valid)
      {
        this.toastrService.success("Note saved successfully", "Success");
      }
  }
}
