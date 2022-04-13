import { Component, OnInit } from '@angular/core';
import {getProducts} from '../products';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {

  products: any[] = [];

  ngOnInit(): void {
    this.products = getProducts();
  }

}
