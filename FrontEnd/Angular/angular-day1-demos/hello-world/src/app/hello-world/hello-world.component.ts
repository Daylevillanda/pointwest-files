import { Component } from '@angular/core';

@Component({
  selector: 'app-hello-world',
  templateUrl: './hello-world.component.html',
  styleUrls: ['./hello-world.component.scss']
})
export class HelloWorldComponent {

  name = 'JM';
  font = 'Arial';

  updateName(event: Event) {
    this.name = (event.target as HTMLInputElement).value;
  }

  changeFont(event: Event) {
    this.font = (event.target as HTMLSelectElement).value;
  }

}
