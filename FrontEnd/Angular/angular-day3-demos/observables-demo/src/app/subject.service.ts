import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  private http: HttpClient;
  name$ = new BehaviorSubject('JM');

  constructor(http: HttpClient) {
    this.http = http;
  }

  createTimer() {
    return new Observable<number>(subscriber => {
      let count = 1;
      setInterval(() => {
        subscriber.next(count);
        count++;
      }, 1000);
    });
  }

  setName(name: string) {
    this.name$.next(name);
  }

  getProducts() {
    return this.http.get('https://pw-uiewg-walletapp.firebaseio.com/products.json');
  }

}
