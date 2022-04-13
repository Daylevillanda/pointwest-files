import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProduct } from './models/products';

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {

  private productUrl: string = 'https://pw-uiewg-walletapp.firebaseio.com/products.json';

  constructor(private http: HttpClient) { }

  getProducts(): Observable<IProduct[]> {
    return this.http.get<IProduct[]>(this.productUrl);
  }
}

