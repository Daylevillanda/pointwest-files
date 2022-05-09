import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from '../shared/messaging/message.service';

import { Product } from './product';
import { ProductService } from './product.service';

@Component({
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  searchProduct: Product = new Product({ productName: "" });

  constructor(private productService: ProductService,
    private router: Router,
    private msgService: MessageService) {
  }

  ngOnInit(): void {
    this.getProducts();
  }

  addProduct(): void {
    this.router.navigate(['/productDetail', -1]);
  }

  private getProducts(): void {
    this.msgService.clearAll();
    this.msgService.addInfoMessage("Please wait while loading products...");

    this.productService.getProducts().subscribe(products => this.products = products,
      () => { },
      () => {
        this.msgService.clearInfoMessages();
      });
  }

  search(): void {
    this.msgService.clearAll();
    this.msgService.addInfoMessage(
      "Please wait while searching products...");

    // Clear product list
    this.products = [];

    this.productService.search(this.searchProduct)
      .subscribe(products => this.products = products,
        () => { },
        () => {
          this.searchComplete();
        });
  }

  private searchComplete(): void {
    if (this.msgService.lastException &&
      this.msgService.lastException.status) {
      if (this.msgService.lastException.status === 404) {
        this.msgService.clearAll();
        this.msgService.addInfoMessage(
          "No products match the search criteria entered.");
      }
      else {
        this.msgService.clearInfoMessages()
      }
    }
    else {
      this.msgService.clearInfoMessages()
    }
  }

  reset(): void {
    // Clear search object
    this.searchProduct.productName = "";
    // Clear product list
    this.products = [];
    // Get all products
    this.getProducts();
  }

  private productDeleted() {
    if (this.msgService.exceptionMessages.length) {
      // Display any exception messages
    }
    else {
      // Clear informational messages
      this.msgService.clearInfoMessages();
      // Display informational message
      this.msgService.addInfoMessage("Product was deleted...");

      // After n seconds, clear messages
      setTimeout(() => {
        // Clear all messages
        this.msgService.clearAll();
      }, 1500);
    }
  }

  deleteProduct(id: number): void {
    if (confirm("Delete this product?")) {
      // Go to where the user can see the messages
      window.scrollTo(0, 0);
      // Display informational message
      this.msgService.addInfoMessage(
        "Attempting to delete product...");

      this.productService.deleteProduct(id)
        .subscribe(() => this.products =
          this.products.filter(p => p.productId != id),
          () => { },
          () => this.productDeleted());
    }
  }
}
