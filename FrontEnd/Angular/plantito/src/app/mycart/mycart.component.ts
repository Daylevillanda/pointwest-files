import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ICart } from '../models/carts';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-mycart',
  templateUrl: './mycart.component.html',
  styleUrls: ['./mycart.component.scss']
})
export class MycartComponent implements OnInit {

  cartItems!: ICart [];

  productSvc: ProductService;
  router: Router;
  route:ActivatedRoute;

  cart_index: number = 0;
  showModal = false;

  constructor(route: ActivatedRoute, router: Router, productSvc: ProductService) {
    this.route = route;
    this.router = router;
    this.productSvc = productSvc;
   }

  ngOnInit(): void {
    this.productSvc.carts$.subscribe(carts => {
      this.cartItems = carts;
  })
}
  remove(confirm: string){
    if(confirm == 'yes'){
      this.productSvc.deleteCart(this.cart_index);
    }
    this.showModal = false;
}
  getTotalQuantity() {
    return this.productSvc.getTotalCart();
  }

  activateModal(index: number){
    this.showModal = true;
    this.cart_index = index;
  }
}