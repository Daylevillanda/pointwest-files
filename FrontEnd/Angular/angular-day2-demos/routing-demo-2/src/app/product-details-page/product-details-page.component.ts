import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { getProductById } from '../products';

@Component({
  selector: 'app-product-details-page',
  templateUrl: './product-details-page.component.html',
  styleUrls: ['./product-details-page.component.scss']
})
export class ProductDetailsPageComponent implements OnInit {

  route: ActivatedRoute;
  product: any = null;

  constructor(route: ActivatedRoute) {
    this.route = route;
  }

  ngOnInit(): void {
    let id = this.route.snapshot.paramMap.get('id');
    if (id !== null) {
      this.product = getProductById(id);
    }
  }

}
