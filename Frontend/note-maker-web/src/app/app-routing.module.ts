import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNoteComponent } from './add-note/add-note.component';
import { EditNoteComponent } from './edit-note/edit-note.component';
import { NoteMainComponent } from './note-main/note-main.component';

const routes: Routes = [
  {path: 'home', component: NoteMainComponent},
  {path: 'add-note', component: AddNoteComponent},
  {path: 'edit-note/:id', component: EditNoteComponent},
  {path: '', pathMatch: 'full', redirectTo: 'home'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
