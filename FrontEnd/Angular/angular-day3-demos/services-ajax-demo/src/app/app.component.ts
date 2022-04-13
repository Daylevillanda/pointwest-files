import { Component, OnInit } from '@angular/core';
import { Product } from './models/product';
import { SampleService } from './sample.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  private sample: SampleService;
  products: Product[] | undefined = [];
  
  constructor(sample: SampleService) {
    this.sample = sample;
  }

  async ngOnInit() {
    this.products = await this.sample.getProducts();
  }

  doMath() {
    return this.sample.add(2, 3);
  }

}
