import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Category } from '../category/category';
import { CategoryService } from '../category/category.service';
import { Product } from './product';
import { ProductService } from './product.service';
import { CanComponentDeactivate } from '../shared/guards/not-saved.guard';
import { DialogService } from '../shared/dialog.service';
import { Observable } from 'rxjs';
import { MessageService } from '../shared/messaging/message.service';

@Component({
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit, CanComponentDeactivate {
  product: Product | undefined;
  originalProduct: Product | undefined;
  categories: Category[] = [];

  constructor(private categoryService: CategoryService,
    private productService: ProductService,
    private route: ActivatedRoute,
    private location: Location,
    private dialogService: DialogService,
    private msgService: MessageService) { }

  ngOnInit(): void {
    this.msgService.clearAll();
    this.msgService.addInfoMessage("Please wait while loading product...");

    this.getCategories();

    // Get the product id passed on the URL
    let id = Number(this.route.snapshot.paramMap.get('id'));

    // Create or load a product object
    this.createOrLoadProduct(id);
  }

  private createOrLoadProduct(id: number) {
    if (id == -1) {
      // Create new product object
      this.initProduct();
      // Clear any informational messages
      this.msgService.clearInfoMessages();
    }
    else {
      // Get a product from product service
      this.productService.getProduct(id)
        .subscribe(product => {
          this.product = product;
          this.originalProduct = Object.assign({}, this.product)
        },
          () => { },
          () => {
            if (this.msgService.exceptionMessages.length) {
              this.product = undefined;
            }

            this.msgService.clearInfoMessages();
          });
    }
  }

  private initProduct(): void {
    // Add a new product
    this.product = new Product({
      introductionDate: new Date(),
      price: 1,
      url: "www.pdsa.com"
    });
    this.originalProduct = Object.assign({}, this.product);
  }

  canDeactivate(): Observable<boolean> | boolean {
    // Determine if product is unchanged.
    if (JSON.stringify(this.product) !==
      JSON.stringify(this.originalProduct)) {
      // If product has changed, ask the user to 
      // confirm they wish to leave this page.
      return this.dialogService.confirm('Discard changes?');
    }
    else {
      // Put the original product data back
      this.product = Object.assign({}, this.originalProduct);
      return true;
    }
  }

  saveData(): void {
    // Clear any old messages
    this.msgService.clearAll();

    // Display informational message
    this.msgService.addInfoMessage(
      "Attempting to save product information...");

    // Fix up any data stuff for product
    if (this.product!.categoryId) {
      this.product!.categoryId = Number(this.product!.categoryId);
    }

    if (this.product!.productId) {
      // Update product
      this.productService.updateProduct(this.product!)
        .subscribe(product => { this.product = product },
          () => null,
          () => this.dataSaved());
    }
    else {
      // Add a product
      this.productService.addProduct(this.product!)
        .subscribe(product => { this.product = product },
          () => null,
          () => this.dataSaved());
    }
  }

  private dataSaved(): void {
    // Clear informational messages
    this.msgService.clearInfoMessages();

    if (this.msgService.exceptionMessages.length) {
      // Display any exception messages
    }
    else {
      // Display informational message
      this.msgService.addInfoMessage(
        "Product has been saved...");
      // Reset product objects to hide form
      this.product = undefined;
      this.originalProduct = undefined;

      // After n seconds, reinitialize the page
      setTimeout(() => {
        // Clear all messages
        this.msgService.clearAll();

        // Redirect back to list
        this.goBack();
      }, 1500);
    }
  }

  goBack(): void {
    this.location.back();
  }

  cancel(): void {
    this.goBack();
  }

  private getCategories(): void {
    this.categoryService.getCategories()
      .subscribe(categories => this.categories = categories);
  }
}
