import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataTransferService {

  private messageSource: any = new BehaviorSubject("Default");
  constructor() { }
  fetchMessage(): Observable<any> {
    return this.messageSource.asObservable();
  }

  sendMessage(message: any) {
    this.messageSource.next(message)
  }
}
