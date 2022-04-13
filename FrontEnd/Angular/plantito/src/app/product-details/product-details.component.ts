import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IProducts, IReview } from '../models/products';
import { ProductService } from '../product.service';
import { ICart } from '../models/carts';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  route: ActivatedRoute;
  productService: ProductService;
  myForm: FormGroup;
  product!: IProducts;
  router: Router;
  
  product_id: string = "";

  product_rating: number = 0;
  review_count: number= 0;
  order_quantity = 1;
  showModal = false;

  carts$: BehaviorSubject<ICart[]>;
  

  constructor(route: ActivatedRoute, productService: ProductService, fb: FormBuilder, router: Router) {
    this.route = route;
    this.productService = productService;

    this.myForm = fb.group({
      quantity: [1, [Validators.pattern(/^(0*[1-9][0-9]*)$/), Validators.required]]
    });

    this.router = router;
    this.carts$ = productService.carts$;
  }

  ngOnInit(): void {
    this.product_id = this.route.snapshot.paramMap.get('id') as string;
    this.productService.getProducts().subscribe(products =>{
      this.product = products.find(element => element.productId == parseInt(this.product_id))!;
    });

    this.product_rating = this.getAveRating(this.product.productReview);
    this.review_count = this.getReviewCount(this.product.productReview);
  }

  getAveRating(productReview: IReview[]): number{
    console.log("ave rating");
    return this.productService.getAveRating(productReview);
  }
  
  getReviewCount(productReview: IReview[]): number{
    return this.productService.getReviewCount(productReview);
  }

  createStarArray(rating: number): number[]{
    return this.productService.createStarArray(rating);
  }

  createGrayStar(rating: number): number[]{
    return this.productService.createStarArray(5-rating);
  }

  activateModal(){
    this.showModal = true;
  }
  confirmPurchase(value: string){
    if(value == 'yes'){
      this.addToCard();
    }
    else{
      this.showModal = false;
    }
  }

  addToCard(){
    let quantity = this.quantity?.value;

    if(quantity == null){
      quantity = 1;
    }

    let item: ICart = {
      productid: this.product.productId,
      productName: this.product.productName,
      productTotalPrice: this.product.productPrice * quantity,
      productTotalQuantity: quantity,
      productPhoto: this.product.productPhoto
    }
    console.log(item);
    if (this.ifExist()){
      let cart = this.carts$.value;
      let cart_index = this.carts$.value.map(product => {
        return product.productid;
      }).indexOf(this.product.productId);

      item.productTotalPrice += cart[cart_index].productTotalPrice;
      item.productTotalQuantity += cart[cart_index].productTotalQuantity;

      this.productService.updateCart(cart_index, item);
    }
    else{
      this.productService.addCart(item);
    }

    this.router.navigate(["carts"]);
  }

  get quantity(){
    return this.myForm.get("quantity");
  }

  ifExist(): boolean{
    for (let item of this.carts$.value){
      if(this.product.productId == item.productid){
        return true;
      }
    }
    return false;
  }
}
