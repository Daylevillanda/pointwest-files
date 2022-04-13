import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { IProducts } from './models/products';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  products$ = new BehaviorSubject<IProducts[]>([
    {
      productPhoto:"sample",
      productName:"sample",
      productPrice:123,
      productReview:[
        { 
          reviewUserName: "sample",
          reviewDate: "sample",
          reviewContent: "sample",
          reviewRating: 123
        },
        { 
          reviewUserName: "sample",
          reviewDate: "sample",
          reviewContent: "sample",
          reviewRating: 123
        }]
    }
  ]);
  carts$ = new BehaviorSubject<IProducts[]>([]);

  getProducts(): Observable<IProducts[]> {
    return of([
      {
        productPhoto:"sample",
        productName:"sample",
        productPrice:123,
        productReview:[
          { 
            reviewUserName: "sample",
            reviewDate: "sample",
            reviewContent: "sample",
            reviewRating: 123
          },
          { 
            reviewUserName: "sample",
            reviewDate: "sample",
            reviewContent: "sample",
            reviewRating: 123
          }]
      },
      {
        productPhoto:"sample",
        productName:"sample",
        productPrice:123,
        productReview:[
          { 
            reviewUserName: "sample",
            reviewDate: "sample",
            reviewContent: "sample",
            reviewRating: 123
          },
          { 
            reviewUserName: "sample",
            reviewDate: "sample",
            reviewContent: "sample",
            reviewRating: 123
          }]
      }
    ])
  }
}

