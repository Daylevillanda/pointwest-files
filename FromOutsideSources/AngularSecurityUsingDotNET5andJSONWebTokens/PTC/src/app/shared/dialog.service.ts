import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DialogService {

  constructor() { }

  confirm(message?: string) : Observable<boolean> {
    let ret: boolean = window.confirm(message || 'Are you sure?');
  
    return of<boolean>(ret);
  }
 
}
