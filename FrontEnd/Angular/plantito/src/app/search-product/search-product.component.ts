import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProducts, IReview } from '../models/products';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-search-product',
  templateUrl: './search-product.component.html',
  styleUrls: ['./search-product.component.scss']
})
export class SearchProductComponent implements OnInit {

  products: IProducts[]=[];
  inputSearch!: string;

  constructor(private svc: ProductService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.svc.getProducts().subscribe({
      next: products => this.products = products
    });
  }

  getFilteredProduct(): IProducts[]{
    this.inputSearch = (this.route.snapshot.paramMap.get('Input'))!;
    
    return this.products.filter((product) =>{
      return (product.productName.toLowerCase().includes(this.inputSearch.toLowerCase()) || 
      product.productDescription.toLowerCase().includes(this.inputSearch.toLowerCase()))
    })
  }

  getAvgRating(productReview: IReview[]): number{
    return this.svc.getAveRating(productReview);
  }

  getReviewCount(productReview: IReview[]): number{
    return this.svc.getReviewCount(productReview);
  }

}
