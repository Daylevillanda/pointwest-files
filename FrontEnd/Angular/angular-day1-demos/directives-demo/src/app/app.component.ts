import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  foods = [
    {name: 'Balut', price: 50},
    {name: 'Squid Ball 5pcs', price: 50},
    {name: 'Fish Ball 5pcs', price: 40},
    {name: 'One Day Old', price: 100},
    {name: 'Kwek Kwek (3pcs)', price: 150}
  ];
  isLoggedIn = false;
  language = 'en';
  ngClassOptions = {
    red: false,
    emphasis: false,
    alien: false
  };
  ngStyleOptions = {
    fontFamily: 'Arial',
    fontSize: '16px'
  };

  setIsLoggedIn(event: Event) {
    this.isLoggedIn = (event.target as HTMLInputElement).checked;
  }

  setLanguage(event: Event) {
    this.language = (event.target as HTMLSelectElement).value;
  }

  setNgClass(event: Event, className: string) {
    (this.ngClassOptions as any)[className] = (event.target as HTMLInputElement).checked;
  }

  setStyle(event: Event, property: string) {
    (this.ngStyleOptions as any)[property] = (event.target as HTMLSelectElement).value;
  }
}
