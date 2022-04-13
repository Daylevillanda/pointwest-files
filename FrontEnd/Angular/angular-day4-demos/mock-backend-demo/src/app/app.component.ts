import { Component, OnInit } from '@angular/core';
import { FakeBackendService } from './fake-backend.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  
  backend: FakeBackendService;
  products: any[] = [];

  constructor(backend: FakeBackendService) {
    this.backend = backend;
  }

  ngOnInit() {
    this.backend.getProducts().subscribe(products => {
      this.products = products
    });
  }
}
