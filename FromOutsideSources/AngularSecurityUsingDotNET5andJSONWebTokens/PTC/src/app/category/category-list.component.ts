import { Component, OnInit } from '@angular/core';

import { Category } from './category';
import { CategoryService } from './category.service';
import { MessageService } from '../shared/messaging/message.service';

@Component({
  selector: 'ptc-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  categories: Category[] | undefined;

  constructor(private categoryService: CategoryService,
  private msgService: MessageService) { }

  ngOnInit(): void {
    this.getCategories();
  }

  private getCategories(): void {
    this.msgService.clearAll();
    this.msgService.addInfoMessage(
       "Please wait while loading categories...");
  
    this.categoryService.getCategories()
      .subscribe(categories => this.categories = categories,
      () => { },
      () => {
        this.msgService.clearInfoMessages();
      });
  }  
}
