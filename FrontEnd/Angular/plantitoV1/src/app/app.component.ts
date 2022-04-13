import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { IProducts } from './models/products';
import { ProductService } from './product.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'plantito';

  products$: BehaviorSubject<IProducts[]>;//1st way
  products2$: Observable<IProducts[]>;//3nd way
  products: IProducts[]=[];//2nd way

  constructor(private svc: ProductService){
    this.products$ = this.svc.products$; //1st way
    this.products2$ = this.svc.getProducts(); //3nd way
  }

  ngOnInit(): void {
    this.svc.getProducts().subscribe({ //2nd way
      next: products => this.products = products
      // error: err => this.errorMessage = err -> To return error
    });
  }
}
