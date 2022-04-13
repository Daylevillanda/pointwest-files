import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'forms-demo';
  formData: any[] = [];

  handleReactiveFormSubmit(data: any) {
    this.formData.push(data);
  }
}
