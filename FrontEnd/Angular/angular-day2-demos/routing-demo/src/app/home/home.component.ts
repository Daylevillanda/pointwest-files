import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  private router: Router;

  products = [
    'bentilador',
    'aircon',
    'mist-fan'
  ];

  constructor(router: Router) {
    this.router = router;
  }

  buttonClicked() {
    this.router.navigate(['about']);
  }

}
