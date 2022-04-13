import { Component, OnInit } from '@angular/core';
import { IProducts, IReview } from '../models/products';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {

  service: ProductService;
  products: IProducts [] = [];

  constructor(service: ProductService) {
    this.service = service;
   }

  ngOnInit() {
    this.service.getProducts().subscribe(products => {
      this.products = products
    });
  }
  getAvRating(productReview: IReview []): number {
    return this.service.getAveRating(productReview)
  }
  getRevCount(productReview : IReview[]): number {
    return this.service.getReviewCount(productReview)
  }

}
