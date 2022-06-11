import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError, map, Observable, throwError } from 'rxjs';
import { NoteModel } from 'src/models/NoteModel';

const endPoint: string = 'http://localhost:6897/api/notemaker/';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private client: HttpClient) { }
  
  private handleError(error: HttpErrorResponse): any {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    return throwError(
      new Error('Something bad happened; please try again later.'));
  }
  public addNote(note: NoteModel) : Observable<any>
  {
    const headers = { 'content-type': 'application/json'}  
    const body = JSON.stringify(note);
    return this.client.post(endPoint + 'note', body, {'headers': headers }).pipe(catchError(this.handleError));
  }
  public editNote(note: NoteModel) : Observable<any>
  {
    const headers = { 'content-type': 'application/json'}  
    const body = JSON.stringify(note);
    return this.client.put(endPoint + 'note/' + note.id, body, {'headers': headers }).pipe(catchError(this.handleError));
  }
  public deleteNote(noteId: number) : Observable<any>
  {
    return this.client.delete(endPoint + 'note/' + noteId).pipe(catchError(this.handleError));
  }
  public getAllNotes() : Observable<NoteModel[]>
  {
    return this.client.get<NoteModel[]>(endPoint + 'notes').pipe( map(
      data => 
      {
        return data.map(note =>
          {
            return new NoteModel(
              {
                id: note['id'],
                noteTitle: note['noteTitle'],
                noteContent: note['noteContent'],
                starred: note['starred'],
                createdTime: note['createdTime'],
                modifiedTime: note['modifiedTime']
              }
            );
          });
      }
    ));
  }
}
