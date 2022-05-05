import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IProduct } from './models/products';
import { ProductServiceService } from './product-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {

  products: IProduct[] = [];

  sub!: Subscription;
  // Two ways to handle sub: Subscription;
  // 1. sub: Subscription | undefined; -> Can be undefined
  // 2. sub!: Subscription; -> Handle the assignment later

  constructor(private service: ProductServiceService) {}

  ngOnInit(): void {
    this.sub = this.service.getProducts().subscribe({
      next: products => this.products = products
      // error: err => this.errorMessage = err -> To return error
    });
    console.log(this.products);
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

}
