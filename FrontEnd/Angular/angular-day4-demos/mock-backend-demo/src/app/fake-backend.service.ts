import { Injectable } from '@angular/core';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FakeBackendService {

  getProducts() {
    return of([
      {id: 1, name: 'one'},
      {id: 2, name: 'two'}
    ]);
  }

}
